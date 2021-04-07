using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class NewsItemModel
    {
        public Guid IDNewsItem { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage ="String too long (max. 250 chars)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidTo { get; set; }

        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Tags { get; set; }
    }
}