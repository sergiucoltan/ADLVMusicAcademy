using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ADLVMusicAcademy.Models
{
    public class CourseModel
    {  
        
        public Guid IDCourse { get; set; }

        public Guid IDTeacher { get; set; }

        [DisplayName("Teacher")]
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        [DisplayName("Course Name")]
        public string CourseName { get; set; }

    }
}