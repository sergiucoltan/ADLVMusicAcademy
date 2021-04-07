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
            List<NewsItemModel> newsItems = newsItemRepository.GetAllNewsItems();

            return View("Index", newsItems);
        }

        // GET: NewsItem/Details/5
        public ActionResult Details(Guid id)
        {
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("NewsItemDetails", newsItemModel);
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
        public ActionResult Edit(Guid id)
        {
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("EditNewsItem", newsItemModel);
        }

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

        // GET: NewsItem/Delete/5
        public ActionResult Delete(Guid id)
        {
            NewsItemModel newsItemModel = newsItemRepository.GetNewsItemById(id);

            return View("DeleteNewsItem", newsItemModel);
        }

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
