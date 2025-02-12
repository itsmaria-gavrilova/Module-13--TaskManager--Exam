using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Data.Models;
using Task_Manager.Models;
using Task_Manager.Data;
using Task = Task_Manager.Data.Models.Task;
using static Task_Manager.Common.AdminUser;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskManagerDbContext _context;

        public TaskController(TaskManagerDbContext context)
        {
            _context = context;
        }

        // Index: List all tasks
        public async Task<IActionResult> Index()
        {
            // Fetch all tasks along with their assigned employee
            var tasks = await _context.Tasks.Include(t => t.EmployeeTasks)
                                            .ThenInclude(et => et.Employee)
                                            .ToListAsync();
            return View(tasks);
        }

        // Create: Display the Create Task form
        public IActionResult Create()
        {
            var viewModel = new TaskViewModel
            {
                AvailableEmployees = _context.Employees.ToList() // Get all employees for task assignment
            };
            return View(viewModel);
        }

        // Create: Handle the POST request to create a new task
        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new task and save it to the database
                var task = new Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    AssignDate = model.AssignDate,
                    EndDate = model.EndDate,
                    EmployeeID=(int)model.AssignedEmployeeID,
                };

                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                // If an employee is assigned, create the relationship between task and employee
                if (model.AssignedEmployeeID.HasValue)
                {
                    var employeeTask = new EmployeeTask
                    {
                        EmployeeID = model.AssignedEmployeeID.Value,
                        TaskID = task.ID,
                        IsCompleted = false // Initially, the task is not completed
                    };

                    _context.EmployeeTasks.Add(employeeTask);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            // If model is invalid, re-display the form with available employees
            model.AvailableEmployees = _context.Employees.ToList();
            return View(model);
        }

        // Edit: Display the Edit Task form
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.Include(t => t.EmployeeTasks)
                                           .ThenInclude(et => et.Employee)
                                           .FirstOrDefaultAsync(t => t.ID == id);
            if (task == null)
            {
                return NotFound();
            }

            var viewModel = new TaskViewModel
            {
                ID = task.ID,
                Title = task.Title,
                Description = task.Description,
                AssignDate = task.AssignDate,
                EndDate = task.EndDate,
                AssignedEmployeeID = task.EmployeeTasks.FirstOrDefault()?.EmployeeID,
                AvailableEmployees = _context.Employees.ToList()
            };

            return View(viewModel);
        }

        // Edit: Handle the POST request to save edited task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskViewModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var task = await _context.Tasks.Include(t => t.EmployeeTasks)
                                               .ThenInclude(et => et.Employee)
                                               .FirstOrDefaultAsync(t => t.ID == id);
                if (task == null)
                {
                    return NotFound();
                }

                task.Title = model.Title;
                task.Description = model.Description;
                task.AssignDate = model.AssignDate;
                task.EndDate = model.EndDate;

                _context.Update(task);

                // Update the EmployeeTask relationship if assigned employee changes
                var existingEmployeeTask = _context.EmployeeTasks
                                                    .FirstOrDefault(et => et.TaskID == id);
                if (existingEmployeeTask != null)
                {
                    existingEmployeeTask.EmployeeID = model.AssignedEmployeeID ?? existingEmployeeTask.EmployeeID;
                    _context.Update(existingEmployeeTask);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // If model is invalid, re-display the form with available employees
            model.AvailableEmployees = _context.Employees.ToList();
            return View(model);
        }

        // Delete: Display the Delete Task confirmation form
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.Include(t => t.EmployeeTasks)
                                           .ThenInclude(et => et.Employee)
                                           .FirstOrDefaultAsync(t => t.ID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Delete: Handle the POST request to delete a task
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            // Remove the relationships with employees
            var employeeTasks = _context.EmployeeTasks.Where(et => et.TaskID == id);
            _context.EmployeeTasks.RemoveRange(employeeTasks);

            // Remove the task
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Assign: Assign a task to an employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTask(int taskId, int employeeId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            var employee = await _context.Employees.FindAsync(employeeId);

            if (task == null || employee == null)
            {
                return NotFound();
            }

            // Create the EmployeeTask relationship
            var employeeTask = new EmployeeTask
            {
                TaskID = taskId,
                EmployeeID = employeeId,
                IsCompleted = false
            };

            _context.EmployeeTasks.Add(employeeTask);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Mark task as completed (for employees)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkTaskAsCompleted(int taskId, int employeeId)
        {
            var employeeTask = await _context.EmployeeTasks
                                              .FirstOrDefaultAsync(et => et.TaskID == taskId && et.EmployeeID == employeeId);

            if (employeeTask == null)
            {
                return NotFound();
            }

            employeeTask.IsCompleted = true;
            _context.Update(employeeTask);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmployeeTasks), new { employeeId });
        }

        // View tasks assigned to an employee (for employees)
        public async Task<IActionResult> EmployeeTasks(int employeeId)
        {
            var employee = await _context.Employees
                                         .Include(e => e.EmployeeTasks)
                                         .ThenInclude(et => et.Task)
                                         .FirstOrDefaultAsync(e => e.ID == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            //var tasks = employee.EmployeeTasks.Select(et => et.Task).ToList();

            var viewModel = new EmployeeViewModel
            {
                ID = employee.ID,
                Name = employee.Name,
                DepartmentID = employee.Department?.ID,
                //Tasks = tasks,
                TaskStatus = employee.EmployeeTasks.ToDictionary(et => et.TaskID, et => et.IsCompleted) // Track task completion
            };

            return View(viewModel);
        }
    }
}
