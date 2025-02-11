using System.Collections.Generic;
using Task_Manager.Models;

namespace Task_Manager.Models
{
    public class TaskListViewModel
    {
        public List<Task> Tasks { get; set; }

        // Can be used for filtering tasks by employee
        public int? EmployeeID { get; set; }

        // Can be used for filtering tasks by department
        public int? DepartmentID { get; set; }

        // Can be used to indicate if only incomplete tasks should be shown
        public bool ShowIncompleteOnly { get; set; }
    }
}