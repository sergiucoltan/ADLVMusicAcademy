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

        public List<TeacherModel> GetTeacherByUsername(string userName)
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();
            foreach (Teacher dbTeacher in dbContext.Teachers.Where(x => x.Username.Contains(userName)))
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

        public void UpdateStudent(TeacherModel teacher)
        {
            Teacher teacherDb = dbContext.Teachers.FirstOrDefault(x => x.IdTeacher == teacher.IDTeacher);
            if(teacherDb != null)
            {
                teacherDb.IdTeacher = teacher.IDTeacher;
                teacherDb.Username = teacher.Username;
                teacherDb.Password = teacher.Password;
                teacherDb.E_mail = teacher.E_mail;
                teacherDb.FirstName = teacher.FirstName;
                teacherDb.LastName = teacher.LastName;
                teacherDb.DateOfBirth = teacher.DateOfBirth;
                teacherDb.Address = teacher.Address;
                teacherDb.Mobile = teacher.Mobile;
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
                teacherDb.Username = teacher.Username;
                teacherDb.Password = teacher.Password;
                teacherDb.E_mail = teacher.E_mail;
                teacherDb.FirstName = teacher.FirstName;
                teacherDb.LastName = teacher.LastName;
                teacherDb.DateOfBirth = teacher.DateOfBirth;
                teacherDb.Address = teacher.Address;
                teacherDb.Mobile = teacher.Mobile;

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
                teacher.Username = dbTeacher.Username;
                teacher.Password = dbTeacher.Password;
                teacher.E_mail = dbTeacher.E_mail;
                teacher.FirstName = dbTeacher.FirstName;
                teacher.LastName = dbTeacher.LastName;
                teacher.DateOfBirth = dbTeacher.DateOfBirth;
                teacher.Address = dbTeacher.Address;
                teacher.Mobile = dbTeacher.Mobile;

                return teacher;
            }

            return null;
        }
    }
}