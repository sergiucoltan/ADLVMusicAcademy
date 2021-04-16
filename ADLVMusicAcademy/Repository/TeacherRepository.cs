using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class TeacherRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public TeacherRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public TeacherRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<TeacherModel> GetAllTeachers()
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();

            foreach(Teacher dbTeacher in dbContext.Teachers)
            {
                teacherList.Add(MapDbObjectToModel(dbTeacher));
            }
            return teacherList;
        }

        public TeacherModel GetTeacherById(Guid ID)
        {
            var teacher = dbContext.Teachers.FirstOrDefault(x => x.IdTeacher == ID);

            return MapDbObjectToModel(teacher);
        }

        public List<TeacherModel> GetTeacherByEmail(string email)
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();
            foreach (Teacher dbTeacher in dbContext.Teachers.Where(x => x.E_mail.Contains(email)))
            {
                teacherList.Add(MapDbObjectToModel(dbTeacher));
            }
            return teacherList;
        }

        public List<TeacherModel> GetTeacherByName(string name)
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();
            foreach (Teacher dbTeacher in dbContext.Teachers.Where(x => x.FirstName == name || x.LastName == name))
            {
                teacherList.Add(MapDbObjectToModel(dbTeacher));
            }
            return teacherList;
        }

        public void InsertTeacher(TeacherModel teacher)
        {
            teacher.IDTeacher = Guid.NewGuid();
            dbContext.Teachers.InsertOnSubmit(MapModelToDbObject(teacher));
            dbContext.SubmitChanges();
        }

        public void UpdateTeacher(TeacherModel teacher)
        {
            Teacher teacherDb = dbContext.Teachers.FirstOrDefault(x => x.IdTeacher == teacher.IDTeacher);
            if(teacherDb != null)
            {
                teacherDb.IdTeacher = teacher.IDTeacher;
                teacherDb.FirstName = teacher.FirstName;
                teacherDb.LastName = teacher.LastName;
                teacherDb.Address = teacher.Address;
                teacherDb.E_mail = teacher.E_mail;
                teacherDb.Mobile = teacher.Mobile;
                teacherDb.Photo = teacher.Photo;
                teacherDb.AlternateText = teacher.AlternateText;
                teacherDb.Speciality = teacher.Speciality;
                teacherDb.Description = teacher.Description;

                dbContext.SubmitChanges();
            }
        }

        public void DeleteTeacher(Guid ID)
        {
            Teacher teacherDb = dbContext.Teachers.FirstOrDefault(x => x.IdTeacher == ID);

            if (teacherDb != null)
            {
                dbContext.Teachers.DeleteOnSubmit(teacherDb);
                dbContext.SubmitChanges();
            }
        }
        private Teacher MapModelToDbObject(TeacherModel teacher)
        {
            Teacher teacherDb = new Teacher();

            if (teacher != null)
            {
                teacherDb.IdTeacher = teacher.IDTeacher;
                teacherDb.FirstName = teacher.FirstName;
                teacherDb.LastName = teacher.LastName;
                teacherDb.Address = teacher.Address;
                teacherDb.E_mail = teacher.E_mail;
                teacherDb.Mobile = teacher.Mobile;
                teacherDb.Photo = teacher.Photo;
                teacherDb.AlternateText = teacher.AlternateText;
                teacherDb.Speciality = teacher.Speciality;
                teacherDb.Description = teacher.Description;


                return teacherDb;
            }

            return null;
        }

        private TeacherModel MapDbObjectToModel(Teacher dbTeacher)
        {
            TeacherModel teacher = new TeacherModel();

            if (dbTeacher != null)
            {
                teacher.IDTeacher = dbTeacher.IdTeacher;
                teacher.FirstName = dbTeacher.FirstName;
                teacher.LastName = dbTeacher.LastName;
                teacher.Address = dbTeacher.Address;
                teacher.E_mail = dbTeacher.E_mail;
                teacher.Mobile = dbTeacher.Mobile;
                teacher.Photo = dbTeacher.Photo;
                teacher.AlternateText = dbTeacher.AlternateText;
                teacher.Speciality = dbTeacher.Speciality;
                teacher.Description = dbTeacher.Description;


                return teacher;
            }

            return null;
        }
    }
}