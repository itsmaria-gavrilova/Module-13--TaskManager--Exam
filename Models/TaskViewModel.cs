using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task_Manager.Data;
using Task_Manager.Data.Models;
using Task_Manager.Models;

namespace Task_Manager.Models
{
    public class TaskViewModel
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Assign Date is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(TaskViewModel), nameof(ValidateAssignDate))]
        public DateTime AssignDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(TaskViewModel), nameof(ValidateEndDate))]
        public DateTime EndDate { get; set; }

        public int? AssignedEmployeeID { get; set; }
        
        public List<Employee>? AvailableEmployees { get; set; }

        // Custom validation methods
        public static ValidationResult ValidateAssignDate(DateTime assignDate, ValidationContext context)
        {
            if (assignDate < DateTime.Today)
            {
                return new ValidationResult("Assign date cannot be in the past.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)
        {
            if (endDate < DateTime.Today)
            {
                return new ValidationResult("End date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }

}
