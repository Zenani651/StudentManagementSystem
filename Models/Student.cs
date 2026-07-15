using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Models
{
    [Index(nameof(StudentNumber), IsUnique = true)]
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; } = true;

        //navigation property for enrollments
        public ICollection<Enrollment> Enrollments { get; set; }
         = new List<Enrollment>();
    }
}