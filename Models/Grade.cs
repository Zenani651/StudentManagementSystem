using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int EnrollmentId { get; set; }
        public string Mark { get; set; } = string.Empty;
        public string LetterGrade { get; set; } = string.Empty;
    }
}