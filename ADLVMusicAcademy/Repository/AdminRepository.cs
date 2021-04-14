using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class AdminRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public AdminRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public AdminRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<AdminModel> GetAllAdmins()
        {
            List<AdminModel> adminList = new List<AdminModel>();

            foreach (Admin dbAdmin in dbContext.Admins)
            {
                adminList.Add(MapDbObjectToModel(dbAdmin));
            }
            return adminList;
        }
        

        public AdminModel GetAdminById(Guid ID)
        {
            var admin = dbContext.Admins.FirstOrDefault(x => x.IdAdmin == ID);

            return MapDbObjectToModel(admin);
        }

        public List<AdminModel> GetAdminByEmail(string email)
        {
            List<AdminModel> adminList = new List<AdminModel>();
            foreach (Admin dbAdmin in dbContext.Admins.Where(x => x.E_mail.Contains(email)))
            {
                adminList.Add(MapDbObjectToModel(dbAdmin));
            }
            return adminList;
        }

        public void InsertAdmin(AdminModel admin)
        {
            admin.IDAdmin = Guid.NewGuid();

            dbContext.Admins.InsertOnSubmit(MapModeltoDbObject(admin));
            dbContext.SubmitChanges();
        }

        public void UpdateAdmin(AdminModel admin)
        {
            Admin adminDb = dbContext.Admins.FirstOrDefault(x => x.IdAdmin == admin.IDAdmin);
            if (adminDb != null)
            {
                adminDb.IdAdmin = admin.IDAdmin;
                adminDb.E_mail = admin.E_mail;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteAdmin(Guid ID)
        {
            Admin adminDb = dbContext.Admins.FirstOrDefault(x => x.IdAdmin == ID);

            if (adminDb != null)
            {
                dbContext.Admins.DeleteOnSubmit(adminDb);
                dbContext.SubmitChanges();
            }
        }

        private Admin MapModeltoDbObject(AdminModel admin)
        {
            Admin adminDb = new Admin();

            if (admin != null)
            {
                adminDb.IdAdmin = admin.IDAdmin;
                adminDb.E_mail = admin.E_mail;

                return adminDb;
            }

            return null;
        }

        private AdminModel MapDbObjectToModel(Admin dbAdmin)
        {
            AdminModel admin = new AdminModel();

            if (dbAdmin != null)
            {
                admin.IDAdmin = dbAdmin.IdAdmin;
                admin.E_mail = dbAdmin.E_mail;

                return admin;
            }

            return null;
        }
    }

}