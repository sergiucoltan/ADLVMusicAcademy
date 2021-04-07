using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class CourseModel
    {  
        public Guid IDCourse { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        public string CourseName { get; set; }

    }
}