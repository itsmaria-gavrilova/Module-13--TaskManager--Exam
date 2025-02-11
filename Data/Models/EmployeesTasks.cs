using Task_Manager.Data.Models;

namespace Task_Manager.Data.Models
{
    public class EmployeeTask
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int TaskID { get; set; }
        public Task Task { get; set; }

        public bool IsCompleted { get; set; }
    }
}
