using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class NewsItemRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public NewsItemRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public NewsItemRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<NewsItemModel> GetAllNewsItems()
        {
            List<NewsItemModel> newsItemList = new List<NewsItemModel>();

            foreach(NewsItem dbNewsItem in dbContext.NewsItems)
            {
                newsItemList.Add(MapDbObjectToModel(dbNewsItem));
            }
            return newsItemList;
        }

        public NewsItemModel GetNewsItemById(Guid ID)
        {
            var newsItem = dbContext.NewsItems.FirstOrDefault(x => x.IdNewsItem == ID);

            return MapDbObjectToModel(newsItem);
        }

        public List<NewsItemModel> GetNewsItemsByDates(DateTime validFrom, DateTime validTo)
        {
            List<NewsItemModel> newsItemList = new List<NewsItemModel>();

            //foreach(NewsItem dbNewsItem in dbContext.NewsItems)
            //{
            //    if (dbNewsItem.ValidFrom >= validFrom && dbNewsItem.ValidTo <= validTo)
            //        newsItemList.Add(MapDbObjectToModel(dbNewsItem));
            //}

            foreach (NewsItem dbNewsItem in dbContext.NewsItems.Where(x=>x.ValidFrom >= validFrom && x.ValidTo <= validTo))
            {
                newsItemList.Add(MapDbObjectToModel(dbNewsItem));
            }


            return newsItemList;
        }

        public List<NewsItemModel> GetNewsItemByTitle(string title)
        {
            List<NewsItemModel> newsItemList = new List<NewsItemModel>();
            foreach (NewsItem dbNewsItem in dbContext.NewsItems.Where(x=>x.Title.Contains(title)))
            {
                newsItemList.Add(MapDbObjectToModel(dbNewsItem));
            }
            return newsItemList;
        }

        public void InsertNewsItem(NewsItemModel newsItem)
        {
            newsItem.IDNewsItem = Guid.NewGuid();

            dbContext.NewsItems.InsertOnSubmit(MapModeltoDbObject(newsItem));
            dbContext.SubmitChanges();
        }

        public void UpdateNewsItem(NewsItemModel newsItem)
        {
            NewsItem newsItemDb = dbContext.NewsItems.FirstOrDefault(x => x.IdNewsItem == newsItem.IDNewsItem);
            if(newsItemDb != null)
            {
                newsItemDb.IdNewsItem = newsItem.IDNewsItem;
                newsItemDb.Title = newsItem.Title;
                newsItemDb.Text = newsItem.Text;
                newsItemDb.ValidFrom = newsItem.ValidFrom;
                newsItemDb.ValidTo = newsItem.ValidTo;
                newsItemDb.Tags = newsItem.Tags;

                dbContext.SubmitChanges();
            }
        }

        public void DeleteNewsItem(Guid ID)
        {
            NewsItem newsItemDb = dbContext.NewsItems.FirstOrDefault(x => x.IdNewsItem == ID);

            if(newsItemDb != null)
            {
                dbContext.NewsItems.DeleteOnSubmit(newsItemDb);
                dbContext.SubmitChanges();
            }
        }

        private NewsItem MapModeltoDbObject(NewsItemModel newsItem)
        {
            NewsItem newsItemDb = new NewsItem();

            if (newsItem != null)
            {
                newsItemDb.IdNewsItem = newsItem.IDNewsItem;
                newsItemDb.Title = newsItem.Title;
                newsItemDb.Text = newsItem.Text;
                newsItemDb.ValidFrom = newsItem.ValidFrom;
                newsItemDb.ValidTo = newsItem.ValidTo;
                newsItemDb.Tags = newsItem.Tags;

                return newsItemDb;
            }

            return null;
        }

        private NewsItemModel MapDbObjectToModel(NewsItem dbNewsItem)
        {
            NewsItemModel newsItem = new NewsItemModel();

            if(dbNewsItem != null)
            {
                newsItem.IDNewsItem = dbNewsItem.IdNewsItem;
                newsItem.Title = dbNewsItem.Title;
                newsItem.Text = dbNewsItem.Text;
                newsItem.ValidFrom = dbNewsItem.ValidFrom;
                newsItem.ValidTo = dbNewsItem.ValidTo;
                newsItem.Tags = dbNewsItem.Tags;

                return newsItem;
            }

            return null;
        }
    }

}   