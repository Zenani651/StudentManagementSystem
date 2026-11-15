using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // Display all departments
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // Show Create page
        public IActionResult Create()
        {
            return View();
        }

        // Save new department
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Show Edit page
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // Save edited department
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Show Delete confirmation
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // Delete department
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            var existingDepartment = _context.Departments.Find(department.DepartmentId);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(existingDepartment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}