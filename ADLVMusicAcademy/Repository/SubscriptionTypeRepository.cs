using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class SubscriptionTypeRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public SubscriptionTypeRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public SubscriptionTypeRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        
        public List<SubscriptionTypeModel> GetAllSubscriptionTypes()
        {
            List<SubscriptionTypeModel> subscriptionTypeList = new List<SubscriptionTypeModel>();

            foreach (SubscriptionType dbSubscriptionType in dbContext.SubscriptionTypes)
            {
                subscriptionTypeList.Add(MapDbObjectToModel(dbSubscriptionType));
            }
            return subscriptionTypeList;
        }

        public SubscriptionTypeModel GetSubscriptionTypeById(int ID)
        {
            var subscriptionType = dbContext.SubscriptionTypes.FirstOrDefault(x => x.IdSubscriptionType == ID);

            return MapDbObjectToModel(subscriptionType);
        }

        public List<SubscriptionTypeModel> GetSubscriptionTypesByName(string name)
        {
            List<SubscriptionTypeModel> subscriptionTypeList = new List<SubscriptionTypeModel>();
            foreach (SubscriptionType dbSubscriptionType in dbContext.SubscriptionTypes.Where(x => x.SubscriptionTypeName.Contains(name)))
            {
                subscriptionTypeList.Add(MapDbObjectToModel(dbSubscriptionType));
            }
            return subscriptionTypeList;
        }


        private SubscriptionTypeModel MapDbObjectToModel(SubscriptionType dbSubscriptionType)
        {
            SubscriptionTypeModel subscriptionType = new SubscriptionTypeModel();

            if(dbSubscriptionType != null)
            {
                subscriptionType.IDSubscriptionType = dbSubscriptionType.IdSubscriptionType;
                subscriptionType.SubscriptionTypeName = dbSubscriptionType.SubscriptionTypeName;

                return subscriptionType;
            }

            return null;
        }
    }
}