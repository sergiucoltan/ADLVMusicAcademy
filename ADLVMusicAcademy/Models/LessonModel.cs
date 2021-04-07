using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class LessonModel
    {
        public Guid IDLesson { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDCourse { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDTeacher { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDStudent { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime LessonDate { get; set; }

        [StringLength(2000, ErrorMessage = "String too long (max. 2000 chars)")]
        public string Resources { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public bool Status { get; set; }
    }
}