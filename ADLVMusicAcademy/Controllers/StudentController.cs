using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class StudentController : Controller
    {
        //injectare repository
        private StudentRepository studentRepository = new StudentRepository();

        [Authorize(Roles = "Editor, Admin")]
        // GET: Student
        public ActionResult Index(string sortOrder, string searchString)
        {
            List<StudentModel> students = studentRepository.GetAllStudents();

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParam = string.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            var persons = from s in students select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                persons = persons.Where(s => s.FullName.Contains(searchString) || s.E_mail.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    persons = persons.OrderByDescending(s => s.FullName);
                    break;
                case "email_desc":
                    persons = persons.OrderBy(s => s.E_mail);
                    break;
                default:
                    persons = persons.OrderBy(s => s.FullName);
                    break;
            }

            return View("Index", persons.ToList());



        }

        [Authorize(Roles = "Editor, Admin")]
        // GET: Student/Details/5
        public ActionResult Details(Guid id)
        {
            StudentModel studentModel = studentRepository.GetStudentById(id);
            return View("StudentDetails", studentModel);
        }

        public ActionResult Confirm(Guid id)
        {
            StudentModel studentModel = studentRepository.GetStudentById(id);
            return View("ConfirmStudent", studentModel);
        }

        [Authorize(Roles = "User, Admin")]
        // GET: Student/Create
        public ActionResult Create()
        {
            return View("CreateStudent");
        }
        
        [Authorize(Roles = "User, Admin")]
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                StudentModel studentModel = new StudentModel();
                UpdateModel(studentModel);

                studentRepository.InsertStudent(studentModel);

                return RedirectToAction("Confirm", new { id = studentModel.IDStudent });
            }
            catch
            {
                return View("CreateStudent");
            }
        }

        [Authorize(Roles = "Editor, Admin")]
        // GET: Student/Edit/5
        public ActionResult Edit(Guid id)
        {
            StudentModel studentModel = studentRepository.GetStudentById(id);
            return View("EditStudent", studentModel);
        }

        [Authorize(Roles = "Editor, Admin")]
        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                StudentModel studentModel = new StudentModel();
                UpdateModel(studentModel);
                studentRepository.UpdateStudent(studentModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditStudent");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Student/Delete/5
        public ActionResult Delete(Guid id)
        {
            StudentModel studentModel = studentRepository.GetStudentById(id);
            return View("DeleteStudent", studentModel);
        }
        [Authorize(Roles = "Admin")]
        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                studentRepository.DeleteStudent(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteStudent");
            }
        }
    }
}
