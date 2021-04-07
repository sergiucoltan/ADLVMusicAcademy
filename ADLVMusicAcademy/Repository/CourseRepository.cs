using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class CourseRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public CourseRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public CourseRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> courseList = new List<CourseModel>();

            foreach (Course dbCourse in dbContext.Courses)
            {
                courseList.Add(MapDbObjectToModel(dbCourse));
            }
            return courseList;
        }

        public CourseModel GetCourseById(Guid ID)
        {
            var course = dbContext.Courses.FirstOrDefault(x => x.IdCourse == ID);

            return MapDbObjectToModel(course);
        }

        public List<CourseModel> GetCourseByName(string name)
        {
            List<CourseModel> courseList = new List<CourseModel>();
            foreach (Course dbCourse in dbContext.Courses.Where(x => x.CourseName.Contains(name)))
            {
                courseList.Add(MapDbObjectToModel(dbCourse));
            }
            return courseList;
        }

        public void InsertCourse(CourseModel course)
        {
            course.IDCourse = Guid.NewGuid();

            dbContext.Courses.InsertOnSubmit(MapModelToDbObject(course));
            dbContext.SubmitChanges();
        }

        public void UpdateCourse(CourseModel course)
        {
            Course courseDb = dbContext.Courses.FirstOrDefault(x => x.IdCourse == course.IDCourse);
            if (courseDb != null)
            {
                courseDb.IdCourse = course.IDCourse;
                courseDb.CourseName = course.CourseName;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteCourse(Guid ID)
        {
            Course courseDb = dbContext.Courses.FirstOrDefault(x => x.IdCourse == ID);

            if (courseDb != null)
            {
                dbContext.Courses.DeleteOnSubmit(courseDb);
                dbContext.SubmitChanges();
            }
        }

        private Course MapModelToDbObject(CourseModel course)
        {
            Course courseDb = new Course();

            if (course != null)
            {
                courseDb.IdCourse = course.IDCourse;
                courseDb.CourseName = course.CourseName;

                return courseDb;
            }
            return null;
        }

        private CourseModel MapDbObjectToModel(Course dbCourse)
        {
            CourseModel course = new CourseModel();

            if (dbCourse != null)
            {
                course.IDCourse = dbCourse.IdCourse;
                course.CourseName = dbCourse.CourseName;

                return course;
            }
            return null;
        }
    }
}