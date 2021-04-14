using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class StudentRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public StudentRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public StudentRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> studentList = new List<StudentModel>();

            foreach (Student dbStudent in dbContext.Students)
            {
                studentList.Add(MapDbObjectToModel(dbStudent));
            }
            return studentList;
        }

        public StudentModel GetStudentById(Guid ID)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.IdStudent == ID);

            return MapDbObjectToModel(student);
        }

        public List<StudentModel> GetStudentByEmail(string email)
        {
            List<StudentModel> studentList = new List<StudentModel>();
            foreach (Student dbStudent in dbContext.Students.Where(x => x.E_mail.Contains(email)))
            {
                studentList.Add(MapDbObjectToModel(dbStudent));
            }
            return studentList;
        }

        public List<StudentModel> GetStudentByName(string name)
        {
            List<StudentModel> studentList = new List<StudentModel>();
            foreach (Student dbStudent in dbContext.Students.Where(x => x.LastName.Contains(name) || x.FirstName.Contains(name)))
            {
                studentList.Add(MapDbObjectToModel(dbStudent));
            }
            return studentList;
        }

        public void InsertStudent(StudentModel student)
        {
            student.IDStudent = Guid.NewGuid();

            dbContext.Students.InsertOnSubmit(MapModeltoDbObject(student));
            dbContext.SubmitChanges();
        }

        public void UpdateStudent(StudentModel student)
        {
            Student studentDb = dbContext.Students.FirstOrDefault(x => x.IdStudent == student.IDStudent);
            if (studentDb != null)
            {
                studentDb.IdStudent = student.IDStudent;
                studentDb.FirstName = student.FirstName;
                studentDb.LastName = student.LastName;
                studentDb.Address = student.Address;
                studentDb.E_mail = student.E_mail;
                studentDb.Mobile = student.Mobile;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteStudent(Guid ID)
        {
            Student studentDb = dbContext.Students.FirstOrDefault(x => x.IdStudent == ID);

            if (studentDb != null)
            {
                dbContext.Students.DeleteOnSubmit(studentDb);
                dbContext.SubmitChanges();
            }
        }

        private Student MapModeltoDbObject(StudentModel student)
        {
            Student studentDb = new Student();

            if (student != null)
            {
                studentDb.IdStudent = student.IDStudent;
                studentDb.FirstName = student.FirstName;
                studentDb.LastName = student.LastName;
                studentDb.Address = student.Address;
                studentDb.E_mail = student.E_mail;
                studentDb.Mobile = student.Mobile;

                return studentDb;
            }

            return null;
        }

        private StudentModel MapDbObjectToModel(Student dbStudent)
        {
            StudentModel student = new StudentModel();

            if (dbStudent != null)
            {
                student.IDStudent = dbStudent.IdStudent;
                student.FirstName = dbStudent.FirstName;
                student.LastName = dbStudent.LastName;
                student.Address = dbStudent.Address;
                student.E_mail = dbStudent.E_mail;
                student.Mobile = dbStudent.Mobile;

                return student;
            }

            return null;
        }
    }

}