using ADLVMusicAcademy.Models;
using ADLVMusicAcademy.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Repository
{
    public class LessonRepository
    {
        private ADLVMusicAcademyDBODataContext dbContext;

        public LessonRepository()
        {
            dbContext = new ADLVMusicAcademyDBODataContext();
        }

        public LessonRepository(ADLVMusicAcademyDBODataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<LessonModel> GetAllLessons()
        {
            List<LessonModel> lessonList = new List<LessonModel>();

            foreach (Lesson dbLesson in dbContext.Lessons)
            {
                lessonList.Add(MapDbObjectToModel(dbLesson));
            }
            return lessonList;
        }
        public LessonModel GetLessonById(Guid ID)
        {
            var lesson = dbContext.Lessons.FirstOrDefault(x => x.IdLesson == ID);

            return MapDbObjectToModel(lesson);
        }
        public LessonModel GetLessonByDate(DateTime date)
        {
            var lesson = dbContext.Lessons.FirstOrDefault(x => x.LessonDate == date);

            return MapDbObjectToModel(lesson);
        }

        public List<LessonModel> GetLessonByTitle(string title)
        {
            List<LessonModel> lessonList = new List<LessonModel>();
            foreach (Lesson dbLesson in dbContext.Lessons.Where(x => x.LessonTitle.Contains(title)))
            {
                lessonList.Add(MapDbObjectToModel(dbLesson));
            }
            return lessonList;
        }

        public List<LessonModel> GetLessonByStudentName(string name)
        {
            List<LessonModel> lessonList = new List<LessonModel>();
            if(!string.IsNullOrEmpty(name))
            {
                foreach(Lesson dbLesson in dbContext.Lessons.Where(x => x.Student.LastName == (name) || x.Student.FirstName ==(name)))
                {
                    lessonList.Add(MapDbObjectToModel(dbLesson));
                }
            }

            return lessonList;
        }


        public void InsertLesson(LessonModel lesson)
        {
            lesson.IDLesson = Guid.NewGuid();
            dbContext.Lessons.InsertOnSubmit(MapModelToObject(lesson));
            dbContext.SubmitChanges();
        }

        public void UpdateLesson(LessonModel lesson)
        {
            Lesson lessonDb = dbContext.Lessons.FirstOrDefault(x => x.IdLesson == lesson.IDLesson);
            if (lessonDb != null)
            {
                lessonDb.IdLesson = lesson.IDLesson;
                lessonDb.IdCourse = lesson.IDCourse;
                lessonDb.IdTeacher = lesson.IDTeacher;
                lessonDb.IdStudent = lesson.IDStudent;
                lessonDb.LessonTitle = lesson.LessonTitle;
                lessonDb.LessonSummary = lesson.LessonSummary;
                lessonDb.LessonDate = lesson.LessonDate;
                lessonDb.Resources = lesson.Resources;
                lessonDb.Status = lesson.Status;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteLesson(Guid ID)
        {
            Lesson lessonDb = dbContext.Lessons.FirstOrDefault(x => x.IdLesson == ID);

            if (lessonDb != null)
            {
                dbContext.Lessons.DeleteOnSubmit(lessonDb);
                dbContext.SubmitChanges();
            }
        }

        private Lesson MapModelToObject(LessonModel lesson)
        {
            Lesson lessonDb = new Lesson();

            if (lesson != null)
            {
                lessonDb.IdLesson = lesson.IDLesson;
                lessonDb.IdCourse = lesson.IDCourse;
                lessonDb.IdTeacher = lesson.IDTeacher;
                lessonDb.IdStudent = lesson.IDStudent;
                lessonDb.LessonTitle = lesson.LessonTitle;
                lessonDb.LessonSummary = lesson.LessonSummary;
                lessonDb.LessonDate = lesson.LessonDate;
                lessonDb.Resources = lesson.Resources;
                lessonDb.Status = lesson.Status;

                return lessonDb;
            }
            return null;
        }

        private LessonModel MapDbObjectToModel(Lesson dbLesson)
        {
            LessonModel lesson = new LessonModel();

            if (dbLesson != null)
            {
                lesson.IDLesson = dbLesson.IdLesson;
                lesson.IDCourse= dbLesson.IdCourse;
                lesson.IDTeacher = dbLesson.IdTeacher;
                lesson.IDStudent = dbLesson.IdStudent;
                lesson.LessonTitle = dbLesson.LessonTitle;
                lesson.LessonSummary = dbLesson.LessonSummary;
                lesson.TeacherFirstName = dbLesson.Teacher.FirstName;
                lesson.TeacherLastName = dbLesson.Teacher.LastName;
                lesson.StudentFirstName = dbLesson.Student.FirstName;
                lesson.StudentLastName = dbLesson.Student.LastName;
                lesson.LessonDate = dbLesson.LessonDate;
                lesson.Resources = dbLesson.Resources;
                lesson.Status = dbLesson.Status;

                return lesson;
            }
            return null;
        }
    }
}