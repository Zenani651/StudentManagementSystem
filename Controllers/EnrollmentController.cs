using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                                      .Include(e => e.Student)
                                      .Include(e => e.Course)
                                      .ToList();

            return View(enrollments);
        }
        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students, "StudentId", "FirstName");
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View();
        }

        // Save Enrollment
        [HttpPost]
        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            // Check if the student is already enrolled in the selected course
            bool exists = _context.Enrollments.Any(e =>
                e.StudentId == enrollment.StudentId &&
                e.CourseId == enrollment.CourseId);

            if (exists)
            {
                ModelState.AddModelError("", "This student is already enrolled in this course.");
            }

            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Reload dropdown lists if validation fails
            ViewBag.Students = new SelectList(_context.Students, "StudentId", "FirstName");
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View(enrollment);
        }
        // GET: Enrollment
        public IActionResult Edit(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            ViewBag.Students = new SelectList(_context.Students, "StudentId", "FirstName", enrollment.StudentId);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName", enrollment.CourseId);

            return View(enrollment);
        }

        // POST: Enrollment
        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Update(enrollment);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Students = new SelectList(_context.Students, "StudentId", "FirstName", enrollment.StudentId);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName", enrollment.CourseId);

            return View(enrollment);
        }
        // GET: Enrollment/Delete/5
        public IActionResult Delete(int id)
        {
            var enrollment = _context.Enrollments
                                     .Include(e => e.Student)
                                     .Include(e => e.Course)
                                     .FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}