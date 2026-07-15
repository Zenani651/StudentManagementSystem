using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please enter the course code.")]
        public string CourseCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter the course name.")]
        public string CourseName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select the department.")]

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select the lecturer.")]
        public int LecturerId { get; set; }

        //navigation property for enrollments
        public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
    }
}