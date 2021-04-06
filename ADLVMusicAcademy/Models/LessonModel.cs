using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class LessonModel
    {
        public Guid IDLesson { get; set; }
        public Guid IDCourse { get; set; }
        public Guid IDTeacher { get; set; }
        public Guid IDStudent { get; set; }
        public DateTime LessonDate { get; set; }
        public string Resources { get; set; }
        public byte Status { get; set; }
    }
}