using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class SubscriptionController : Controller
    {
        //injectare repository
        private SubscriptionRepository subscriptionRepository = new SubscriptionRepository();
        private CourseRepository courseRepository = new CourseRepository();
        private StudentRepository studentRepository = new StudentRepository();
        private SubscriptionTypeRepository subscriptionTypeRepository = new SubscriptionTypeRepository();

        // GET: Subscription
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            List<SubscriptionModel> subscriptions = subscriptionRepository.GetAllSubscriptions();
            

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SubscriptionTypeSortParam = string.IsNullOrEmpty(sortOrder) ? "subscriptionType_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "startDate_desc" : "Date";

            var subs = from s in subscriptions select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                subs = subscriptionRepository.GetSubscriptionsByStudentName(searchString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    subs = subs.OrderByDescending(s => s.StudentLastName);
                    break;
                case "subscriptionType_desc":
                    subs = subs.OrderBy(s => s.IDSubscriptionType);
                    break;
                case "Date":
                    subs = subs.OrderBy(s => s.StartDate);
                    break;
                case "startDate_desc":
                    subs = subs.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    subs = subs.OrderBy(s => s.StudentLastName);
                    break;
            }


            return View("Index", subs.ToList());
        }

        // GET: Subscription/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid id)
        {
            SubscriptionModel subscriptionModel = subscriptionRepository.GetSubscriptionById(id);
            return View("SubscriptionDetails", subscriptionModel);
        }

        public ActionResult Confirm(Guid id)
        {
            SubscriptionModel subscriptionModel = subscriptionRepository.GetSubscriptionById(id);
            return View("ConfirmSubscription", subscriptionModel);
        }

        // GET: Subscription/Create
        [Authorize(Roles = "User, Editor, Admin")]
        public ActionResult Create()
        {
                ViewBag.VBCourseList = new SelectList(courseRepository.GetAllCourses(), "IDCourse", "CourseName");
                ViewBag.VBStudentList = new SelectList(studentRepository.GetAllStudents().OrderBy(s => s.FullName), "IDStudent", "FullName");
                ViewBag.VBSubscriptionTypeList = new SelectList(subscriptionTypeRepository.GetAllSubscriptionTypes().OrderBy(s => s.SubscriptionTypeName), "IDSubscriptionType", "SubscriptionTypeName");
            
                return View("CreateSubscription");
        }

        // POST: Subscription/Create
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                SubscriptionModel subscriptionModel = new SubscriptionModel();
                subscriptionModel.IDCourse = Guid.Parse(Request.Form["CourseName"]);
                subscriptionModel.IDStudent = Guid.Parse(Request.Form["FullName"]);
                subscriptionModel.IDSubscriptionType = int.Parse(Request.Form["SubscriptionTypeName"]);
                UpdateModel(subscriptionModel);

                subscriptionRepository.InsertSubscription(subscriptionModel);

                return RedirectToAction("Confirm", new { id = subscriptionModel.IDSubscription });
            }
            catch
            {
                return View("CreateSubscription");
            }
        }

        // GET: Subscription/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            SubscriptionModel subscriptionModel = subscriptionRepository.GetSubscriptionById(id);
            ViewBag.VBCourseList = new SelectList(courseRepository.GetAllCourses(), "IDCourse", "CourseName");
            ViewBag.VBStudentList = new SelectList(studentRepository.GetAllStudents().OrderBy(s => s.FullName), "IDStudent", "FullName");
            ViewBag.VBSubscriptionTypeList = new SelectList(subscriptionTypeRepository.GetAllSubscriptionTypes().OrderBy(s => s.SubscriptionTypeName), "IDSubscriptionType", "SubscriptionTypeName");
            return View("EditSubscription", subscriptionModel);
        }

        // POST: Subscription/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                SubscriptionModel subscriptionModel = new SubscriptionModel();
                                subscriptionModel.IDCourse = Guid.Parse(Request.Form["CourseName"]);
                subscriptionModel.IDStudent = Guid.Parse(Request.Form["FullName"]);
                subscriptionModel.IDSubscriptionType = int.Parse(Request.Form["SubscriptionTypeName"]);
                UpdateModel(subscriptionModel);
                subscriptionRepository.UpdateSubscription(subscriptionModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditSubscription");
            }
        }

        // GET: Subscription/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            SubscriptionModel subscriptionModel = subscriptionRepository.GetSubscriptionById(id);
            return View("DeleteSubscription", subscriptionModel);
        }

        // POST: Subscription/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                subscriptionRepository.DeleteSubscription(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteSubscription");
            }
        }
    }
}
