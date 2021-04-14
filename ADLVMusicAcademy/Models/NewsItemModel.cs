using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class NewsItemModel
    {
        [Display(Name = "Post Id Number")]
        public Guid IDNewsItem { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage ="String too long (max. 250 chars)")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Text { get; set; }

        [Display(Name = "Valid From")]
        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Valid To")]
        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Tags")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string Tags { get; set; }
    }
}