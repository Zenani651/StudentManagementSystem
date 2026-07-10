using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        //variable that allows us to access the database context
        private readonly AppDbContext _context;

        //constructor injecting the database context into the controller
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students
                                   .Where(s => s.IsActive)
                                   .ToList();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            var existingStudent = _context.Students.Find(student.StudentId);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}