using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Data;
using Task_Manager.Data.Models;
using Task_Manager.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TaskManagerDbContext _context;

        public EmployeeController(TaskManagerDbContext context)
        {
            _context = context;
        }

        // GET: Employee/Create
        public async Task<IActionResult> Create()
        {
            // Fetch the list of departments from the database to populate the dropdown
            var departments = await _context.Departments.ToListAsync();

            // Initialize the view model and pass the departments to the view
            var model = new EmployeeViewModel
            {
                Departments = departments
            };

            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new employee entity and save it to the database
                var employee = new Employee
                {
                    Name = model.Name,
                    DepartmentID = model.DepartmentID.Value
                };

                // Save the employee to the database
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                // Redirect to the employee list after creation
                return RedirectToAction(nameof(Index));
            }


            // If model state is invalid, fetch departments again and return the view with validation errors
            model.Departments = await _context.Departments.ToListAsync();
            return View(model);
        }

        // GET: Employee/Index
        public async Task<IActionResult> Index()
        {
            // Fetch all employees from the database
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.Include(t => t.EmployeeTasks)
                                           .ThenInclude(et => et.Task)
                                           .FirstOrDefaultAsync(t => t.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // Delete: Handle the POST request to delete a task
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Remove the relationships with employees
            var employeeTasks = _context.EmployeeTasks.Where(et => et.EmployeeID == id);
            _context.EmployeeTasks.RemoveRange(employeeTasks);

            // Remove the task
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}


