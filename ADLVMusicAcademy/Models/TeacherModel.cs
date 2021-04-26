using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class TeacherModel
    {
        public Guid IDTeacher{ get; set; }

        [DisplayName("Teacher Name")]
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Address { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string E_mail { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(10, ErrorMessage = "String too long (max. 10 chars)")]
        public string Mobile { get; set; }

        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string Photo { get; set; }

        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string AlternateText { get; set; }

        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string Speciality { get; set; }

        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Description { get; set; }
    }
}