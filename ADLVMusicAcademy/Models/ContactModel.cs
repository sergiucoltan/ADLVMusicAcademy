using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class ContactModel
    {
        [Required, Display(Name = "Your Name")]
        public string SenderName { get; set; }
        [Required, Display(Name = "Your Email"), EmailAddress]
        public string SenderEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}