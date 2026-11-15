using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LecturerController : Controller
    {
        private readonly AppDbContext _context;

        public LecturerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lecturers = _context.Lecturers
                                    .Include(l => l.Department)
                                    .ToList();

            return View(lecturers);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Lecturers.Add(lecturer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName");

            return View(lecturer);
        }
        public IActionResult Edit(int id)
        {
            var lecturer = _context.Lecturers.Find(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName",
                lecturer.DepartmentId);

            return View(lecturer);
        }



        [HttpPost]
        public IActionResult Edit(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Lecturers.Update(lecturer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName",
                lecturer.DepartmentId);

            return View(lecturer);
        }

        public IActionResult Delete(int id)
        {
            var lecturer = _context.Lecturers.Find(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        [HttpPost]
        public IActionResult Delete(Lecturer lecturer)
        {
            var existingLecturer = _context.Lecturers.Find(lecturer.LecturerId);

            if (existingLecturer == null)
            {
                return NotFound();
            }

            _context.Lecturers.Remove(existingLecturer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}