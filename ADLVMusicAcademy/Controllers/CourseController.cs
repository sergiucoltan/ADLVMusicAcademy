using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class CourseController : Controller
    {

        //injectare repository
        private CourseRepository courseRepository = new CourseRepository();

        // GET: Course
        public ActionResult Index()
        {
            List<CourseModel> courseModel = courseRepository.GetAllCourses();
            return View("Index", courseModel);
        }

        // GET: Course/Details/5
        public ActionResult Details(Guid id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);
            return View("CourseDetails", courseModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View("CreateCourse");
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CourseModel courseModel = new CourseModel();
                UpdateModel(courseModel);
                courseRepository.InsertCourse(courseModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCourse");
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(Guid id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);
            return View("EditCourse", courseModel);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CourseModel courseModel = new CourseModel();
                UpdateModel(courseModel);
                courseRepository.UpdateCourse(courseModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCourse");
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(Guid id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);
            return View("DeleteCourse", courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                courseRepository.DeleteCourse(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCourse");
            }
        }
    }
}
