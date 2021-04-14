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

        [AllowAnonymous]
        // GET: NewsItem
        public ActionResult Index()
        {
            List<NewsItemModel> newsItems = newsItemRepository.GetAllNewsItems();

            return View("Index", newsItems);
        }

        // GET: NewsItem/Details/5
        public ActionResult Details(Guid id)
        { 
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("NewsItemDetails", newsItemModel);
        }

        [Authorize(Roles = "User, Editor, Admin")]
        // GET: NewsItem/Create
        public ActionResult Create()
        {
            return View("CreateNewsItem");
        }
        [Authorize(Roles = "User, Editor, Admin")]
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

        [Authorize(Roles = "User, Editor, Admin")]
        // GET: NewsItem/Edit/5
        public ActionResult Edit(Guid id)
        {
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("EditNewsItem", newsItemModel);
        }

        [Authorize(Roles = "User, Editor, Admin")]
        // POST: NewsItem/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                NewsItemModel newsItemModel = new NewsItemModel();
                UpdateModel(newsItemModel);
                newsItemRepository.UpdateNewsItem(newsItemModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditNewsItem");
            }
        }

        [Authorize(Roles = "Editor, Admin")]
        // GET: NewsItem/Delete/5
        public ActionResult Delete(Guid id)
        {
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("DeleteNewsItem", newsItemModel);
        }

        [Authorize(Roles = "Editor, Admin")]
        // POST: NewsItem/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                newsItemRepository.DeleteNewsItem(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteNewsItem");
            }
        }
    }
}
