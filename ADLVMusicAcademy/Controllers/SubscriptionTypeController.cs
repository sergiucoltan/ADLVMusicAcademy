using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class SubscriptionTypeController : Controller
    {
        private SubscriptionTypeRepository subscriptionTypeRepository = new SubscriptionTypeRepository();
        // GET: SubscriptionType
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubscriptionType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubscriptionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubscriptionType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubscriptionType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
