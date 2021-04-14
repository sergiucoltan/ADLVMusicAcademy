using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models

{
    public class AdminModel
    {
        public Guid IDAdmin { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string E_mail { get; set; }
    }
}