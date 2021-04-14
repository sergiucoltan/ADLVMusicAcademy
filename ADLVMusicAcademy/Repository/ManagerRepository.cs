using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class ManagerRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public ManagerRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public ManagerRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<ManagerModel> GetAllManagers()
        {
            List<ManagerModel> managerList = new List<ManagerModel>();

            foreach (Manager dbManager in dbContext.Managers)
            {
                managerList.Add(MapDbObjectToModel(dbManager));
            }
            return managerList;
        }

        public ManagerModel GetManagerById(Guid ID)
        {
            var manager = dbContext.Managers.FirstOrDefault(x => x.IdManager == ID);

            return MapDbObjectToModel(manager);
        }

        public List<ManagerModel> GetManagerByEmail(string email)
        {
            List<ManagerModel> managerList = new List<ManagerModel>();
            foreach (Manager dbManager in dbContext.Managers.Where(x => x.E_mail.Contains(email)))
            {
                managerList.Add(MapDbObjectToModel(dbManager));
            }
            return managerList;
        }

        public List<ManagerModel> GetManagerByName(string name)
        {
            List<ManagerModel> managerList = new List<ManagerModel>();
            foreach (Manager dbManager in dbContext.Managers.Where(x => x.LastName.Contains(name) || x.FirstName.Contains(name)))
            {
                managerList.Add(MapDbObjectToModel(dbManager));
            }
            return managerList;
        }

        public void InsertManager(ManagerModel manager)
        {
            manager.IDManager = Guid.NewGuid();

            dbContext.Managers.InsertOnSubmit(MapModeltoDbObject(manager));
            dbContext.SubmitChanges();
        }

        public void UpdateManager(ManagerModel manager)
        {
            Manager managerDb = dbContext.Managers.FirstOrDefault(x => x.IdManager == manager.IDManager);
            if (managerDb != null)
            {
                managerDb.IdManager = manager.IDManager;
                managerDb.FirstName = manager.FirstName;
                managerDb.LastName = manager.LastName;
                managerDb.E_mail = manager.E_mail;
                managerDb.Address = manager.Address;
                managerDb.Mobile = manager.Mobile;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteManager(Guid ID)
        {
            Manager managerDb = dbContext.Managers.FirstOrDefault(x => x.IdManager == ID);

            if (managerDb != null)
            {
                dbContext.Managers.DeleteOnSubmit(managerDb);
                dbContext.SubmitChanges();
            }
        }

        private Manager MapModeltoDbObject(ManagerModel manager)
        {
            Manager managerDb = new Manager();

            if (manager != null)
            {
                managerDb.IdManager = manager.IDManager;
                managerDb.FirstName = manager.FirstName;
                managerDb.LastName = manager.LastName;
                managerDb.E_mail = manager.E_mail;
                managerDb.Address = manager.Address;
                managerDb.Mobile = manager.Mobile;

                return managerDb;
            }

            return null;
        }

        private ManagerModel MapDbObjectToModel(Manager dbManager)
        {
            ManagerModel manager = new ManagerModel();

            if (dbManager != null)
            {
                manager.IDManager = dbManager.IdManager;
                manager.FirstName = dbManager.FirstName;
                manager.LastName = dbManager.LastName;
                manager.E_mail = dbManager.E_mail;
                manager.Address = dbManager.Address;
                manager.Mobile = dbManager.Mobile;

                return manager;
            }

            return null;
        }
    }

}