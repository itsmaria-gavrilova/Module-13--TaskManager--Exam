using System.Collections.Generic;
using Task_Manager.Data.Models;
using Task_Manager.Models;
using Task = Task_Manager.Data.Models.Task;

namespace Task_Manager.Models
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? DepartmentID { get; set; }


        // List of tasks assigned to this employee
        //public List<Task> Tasks { get; set; }

        // Dictionary of task completion status: Key = Task ID, Value = IsCompleted (true/false)
        public Dictionary<int, bool>? TaskStatus { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
