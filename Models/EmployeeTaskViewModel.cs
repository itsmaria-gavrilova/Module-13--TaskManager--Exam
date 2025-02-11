namespace Task_Manager.Models
{
    public class EmployeeTaskViewModel
    {
        public int EmployeeID { get; set; }

        public int TaskID { get; set; }

        public bool IsCompleted { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public string EmployeeName { get; set; }
    }
}
