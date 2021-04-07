using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class TeacherModel
    {
        public Guid IDTeacher{ get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(25, ErrorMessage = "String too long (max. 25 chars)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(25, ErrorMessage = "String too long (max. 25 chars)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string E_mail { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(10, ErrorMessage = "String too long (max. 10 chars)")]
        public string Mobile { get; set; }
    }
}