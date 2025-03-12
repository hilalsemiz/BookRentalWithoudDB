using BookRentalWithoudDB.Data;
using BookRentalWithoudDB.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalWithoudDB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentRespository repository = new StudentRespository();

            var students=repository.GetAllStudents();
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if(student==null)
            {
                return NotFound();
            } else
            {
                return View(student);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentRespository respository = new StudentRespository();
            respository.Insert(student);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            StudentRespository repository = new StudentRespository();
            var existingStudent = repository.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.Surname = student.Surname;
            existingStudent.BirthDate = student.BirthDate;

            repository.Update(existingStudent);  // Veritabanında güncelleme işlemi
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            repository.Delete(id);  // Veritabanından öğrenci silme işlemi
            return RedirectToAction("Index");
        }
    }
}
