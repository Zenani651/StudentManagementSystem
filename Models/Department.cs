using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();

        public ICollection<Lecturer> Lecturers { get; set; }
            = new List<Lecturer>();
    }
}