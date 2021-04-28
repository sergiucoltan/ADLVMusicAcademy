using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class LessonController : Controller
    {
        //injectare repository
        private LessonRepository lessonRepository = new LessonRepository();
        private CourseRepository courseRepository = new CourseRepository();
        private StudentRepository studentRepository = new StudentRepository();
        private TeacherRepository teacherRepository = new TeacherRepository();


        // GET: Lesson
        [Authorize(Roles = "User, Editor, Admin")]
        public ActionResult Index(string searchString)
        {
            List<LessonModel> lessonModels = lessonRepository.GetAllLessons();
            var lessons = from l in lessonModels select l;
            
            if (User.IsInRole("Editor") || User.IsInRole("Admin"))
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    lessons = lessonRepository.GetLessonByStudentName(searchString);
                }
            }

            if (User.IsInRole("User"))
            {
                lessons = lessonRepository.GetLessonByStudentName(searchString);
            }
            return View("Index", lessons.ToList());
        }


        // GET: Lesson/Details/5
        [Authorize(Roles = "User, Editor, Admin")]
        public ActionResult Details(Guid id)
        {
            LessonModel lessonModel = lessonRepository.GetLessonById(id);
            return View("LessonDetails", lessonModel);
        }

        // GET: Lesson/Create
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Create()
        {
            ViewBag.VBCourseList = new SelectList(courseRepository.GetAllCourses(), "IDCourse", "CourseName");
            ViewBag.VBStudentList = new SelectList(studentRepository.GetAllStudents().OrderBy(s => s.FullName), "IDStudent", "FullName");
            ViewBag.VBTeacherList = new SelectList(teacherRepository.GetAllTeachers().OrderBy(s => s.FirstName), "IDTeacher", "FirstName");

            return View("CreateLesson");
        }

        // POST: Lesson/Create
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                LessonModel lessonModel = new LessonModel();

                lessonModel.IDCourse = Guid.Parse(Request.Form["CourseName"]);
                lessonModel.IDStudent = Guid.Parse(Request.Form["FullName"]);
                lessonModel.IDTeacher = Guid.Parse(Request.Form["FirstName"]);

                UpdateModel(lessonModel);

                lessonRepository.InsertLesson(lessonModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateLesson");
            }
        }

        // GET: Lesson/Edit/5
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Edit(Guid id)
        {
            LessonModel lessonModel = lessonRepository.GetLessonById(id);
            return View("EditLesson", lessonModel);
        }

        // POST: Lesson/Edit/5
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                LessonModel lessonModel = new LessonModel();
                UpdateModel(lessonModel);
                lessonRepository.UpdateLesson(lessonModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditLesson");
            }
        }

        // GET: Lesson/Delete/5
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Delete(Guid id)
        {
            LessonModel lessonModel = lessonRepository.GetLessonById(id);
            return View("DeleteLesson", lessonModel);
        }

        // POST: Lesson/Delete/5
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                lessonRepository.DeleteLesson(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteLesson");
            }
        }
    }
}
