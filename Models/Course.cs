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
        [Required]
        public string CourseCode { get; set; } = string.Empty;
        [Required]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int LecturerId { get; set; }

        //navigation property for enrollments
        public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
    }
}