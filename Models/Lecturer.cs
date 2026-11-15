using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Foreign Key
        [Required]
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department? Department { get; set; }

        // Navigation Property
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}