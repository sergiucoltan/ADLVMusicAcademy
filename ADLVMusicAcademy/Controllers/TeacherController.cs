using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class TeacherController : Controller
    {

        //injectare repository
        private TeacherRepository teacherRepository = new TeacherRepository();

        
        // GET: Teacher
        public ActionResult Index(string sortOrder)
        {
            List<TeacherModel> teachers = teacherRepository.GetAllTeachers();

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var persons = from s in teachers select s;

            if (sortOrder == "name_desc") 
            {
                persons = persons.OrderByDescending(s => s.LastName);
            }
            else
            {
                persons = persons.OrderBy(s => s.LastName);
            }

            return View("Index", persons.ToList());
        }

        
        // GET: Teacher/Details/5
        public ActionResult Details(Guid id)
        {
            TeacherModel teacherModel = teacherRepository.GetTeacherById(id);
            return View("TeacherDetails", teacherModel);
        }


        [Authorize(Roles = "Admin")]
        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View("CreateTeacher");
        }

        [Authorize(Roles = "Admin")]
        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TeacherModel teacherModel = new TeacherModel();
                UpdateModel(teacherModel);

                teacherRepository.InsertTeacher(teacherModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateTeacher");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Teacher/Edit/5
        public ActionResult Edit(Guid id)
        {
            TeacherModel teacherModel = teacherRepository.GetTeacherById(id);
            return View("EditTeacher", teacherModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                TeacherModel teacherModel = new TeacherModel();
                UpdateModel(teacherModel);
                teacherRepository.UpdateTeacher(teacherModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditTeacher");
            }
        }


        [Authorize(Roles = "Admin")]
        // GET: Teacher/Delete/5
        public ActionResult Delete(Guid id)
        {
            TeacherModel teacherModel = teacherRepository.GetTeacherById(id);
            return View("DeleteTeacher", teacherModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                teacherRepository.DeleteTeacher(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteTeacher");
            }
        }
    }
}
