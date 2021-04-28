using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class SubscriptionRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public SubscriptionRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public SubscriptionRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<SubscriptionModel> GetAllSubscriptions()
        {
            List<SubscriptionModel> subscriptionList = new List<SubscriptionModel>();

            foreach (Subscription dbSubscription in dbContext.Subscriptions)
            {
                subscriptionList.Add(MapDbObjectToModel(dbSubscription));
            }
            return subscriptionList;
        }

        public SubscriptionModel GetSubscriptionById(Guid ID)
        {
            var subscription = dbContext.Subscriptions.FirstOrDefault(x => x.IdSubscription == ID);

            return MapDbObjectToModel(subscription);
        }

        public List<SubscriptionModel> GetSubscriptionsByStudentName(string name)
        {
            List<SubscriptionModel> subscriptionList = new List<SubscriptionModel>();
            if (!string.IsNullOrEmpty(name))
            {
                foreach (Subscription dbSubscription in dbContext.Subscriptions.Where(x => x.Student.LastName.Contains(name) || x.Student.FirstName.Contains(name)))
                {
                    subscriptionList.Add(MapDbObjectToModel(dbSubscription));
                }
            }
            return subscriptionList;
        }

        public List<SubscriptionModel> GetSubscriptionsBySubscriptionTypeId(int ID)
        {
            List<SubscriptionModel> subscriptionList = new List<SubscriptionModel>();
            foreach (Subscription dbSubscription in dbContext.Subscriptions.Where(x => x.IdSubscriptionType == ID))
            {
                subscriptionList.Add(MapDbObjectToModel(dbSubscription));
            }
            return subscriptionList;
        }

        public void InsertSubscription(SubscriptionModel subscription)
        {
            subscription.IDSubscription = Guid.NewGuid();

            dbContext.Subscriptions.InsertOnSubmit(MapModelToDbObject(subscription));
            dbContext.SubmitChanges();
        }

        public void UpdateSubscription(SubscriptionModel subscription)
        {
            Subscription subscriptionDb = dbContext.Subscriptions.FirstOrDefault(x => x.IdSubscription == subscription.IDSubscription);
            if (subscriptionDb != null)
            {
                subscriptionDb.IdSubscription = subscription.IDSubscription;
                subscriptionDb.IdCourse = subscription.IDCourse;
                subscriptionDb.IdStudent = subscription.IDStudent;
                subscriptionDb.IdSubscriptionType = subscription.IDSubscriptionType;
                subscriptionDb.Student.FirstName = subscription.StudentFirstName;
                subscriptionDb.Student.LastName = subscription.StudentLastName;
                subscriptionDb.StartDate = subscription.StartDate;
                subscriptionDb.EndDate = subscription.EndDate;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteSubscription(Guid ID)
        {
            Subscription subscriptionDb = dbContext.Subscriptions.FirstOrDefault(x => x.IdSubscription == ID);

            if (subscriptionDb != null)
            {
                dbContext.Subscriptions.DeleteOnSubmit(subscriptionDb);
                dbContext.SubmitChanges();
            }
        }

        private Subscription MapModelToDbObject(SubscriptionModel subscription)
        {
            Subscription subscriptionDb = new Subscription();

            if (subscription != null)
            {
                subscriptionDb.IdSubscription = subscription.IDSubscription;
                subscriptionDb.IdCourse = subscription.IDCourse;
                subscriptionDb.IdStudent = subscription.IDStudent;
                subscriptionDb.IdSubscriptionType = subscription.IDSubscriptionType;
                subscriptionDb.StartDate = subscription.StartDate;
                subscriptionDb.EndDate = subscription.EndDate;

                return subscriptionDb;
            }

            return null;
        }

        private SubscriptionModel MapDbObjectToModel(Subscription dbSubscription)
        {
            SubscriptionModel subscription = new SubscriptionModel();

            if (dbSubscription != null)
            {
                subscription.IDSubscription = dbSubscription.IdSubscription;
                subscription.IDCourse = dbSubscription.IdCourse;
                subscription.IDStudent = dbSubscription.IdStudent;
                subscription.IDSubscriptionType = dbSubscription.IdSubscriptionType;
                subscription.SubscriptionTypeName = dbSubscription.SubscriptionType.SubscriptionTypeName;
                subscription.StudentFirstName = dbSubscription.Student.FirstName;
                subscription.StudentLastName = dbSubscription.Student.LastName;
                subscription.StartDate = dbSubscription.StartDate;
                subscription.EndDate = dbSubscription.EndDate;

                return subscription;
            }

            return null;
        }
    }
}