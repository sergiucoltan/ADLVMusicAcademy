using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Controllers
{
    public class NewsItemController : Controller
    {
        //injectare repository
        private NewsItemRepository newsItemRepository = new NewsItemRepository();

        // GET: NewsItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsItem/Create
        public ActionResult Create()
        {
            return View("CreateNewsItem");
        }

        // POST: NewsItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                NewsItemModel newsItemModel = new NewsItemModel();
                UpdateModel(newsItemModel);

                newsItemRepository.InsertNewsItem(newsItemModel);


                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateNewsItem");
            }
        }

        // GET: NewsItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsItem/Edit/5
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

        // GET: NewsItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsItem/Delete/5
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
