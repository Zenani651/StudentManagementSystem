using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers;

[Authorize(Roles = "Admin,Lecturer, Student")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.StudentCount = _context.Students.Count();

        ViewBag.LecturerCount = _context.Lecturers.Count();

        ViewBag.DepartmentCount = _context.Departments.Count();

        ViewBag.CourseCount = _context.Courses.Count();

        ViewBag.EnrollmentCount = _context.Enrollments.Count();

        ViewBag.ActiveStudents = _context.Students.Count(s => s.IsActive);

        return View();
    }
}