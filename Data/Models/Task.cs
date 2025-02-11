using System;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Data.Models
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssignDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int EmployeeID {  get; set; }

        public ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
