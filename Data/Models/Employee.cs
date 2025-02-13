using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Data.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public ICollection<EmployeeTask> EmployeeTasks { get; set; }

    }
}
