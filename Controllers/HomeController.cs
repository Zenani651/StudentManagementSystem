using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers;

public class HomeController : Controller
{
    //gives the controller access to your database.
    private readonly AppDbContext _context;

    //Dependency injection is a design pattern that allows you to inject dependencies into a class rather than creating them within the class itself. 
    // In this case, the AppDbContext is being injected into the HomeController through its constructor. 
    // This allows the controller to access the database context and perform database operations.
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.StudentCount = _context.Students.Count();

        ViewBag.CourseCount = _context.Courses.Count();

        ViewBag.EnrollmentCount = _context.Enrollments.Count();

        ViewBag.ActiveStudents = _context.Students.Count(s => s.IsActive);

        return View();
    }


}
