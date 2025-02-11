using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Data.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
