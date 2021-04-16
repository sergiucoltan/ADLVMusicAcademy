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

        // GET: Subscription
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<SubscriptionModel> subscription = subscriptionRepository.GetAllSubscriptions();
            return View("Index", subscription);
        }

        // GET: Subscription/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid id)
        {
            SubscriptionModel subscriptionModel = subscriptionRepository.GetSubscriptionById(id);

            return View("SubscriptionDetails", subscriptionModel);
        }

        // GET: Subscription/Create
        [Authorize(Roles = "User, Editor, Admin")]
        public ActionResult Create()
        {
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
                UpdateModel(subscriptionModel);

                subscriptionRepository.InsertSubscription(subscriptionModel);

                return RedirectToAction("Index");
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
