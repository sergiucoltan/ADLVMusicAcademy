using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class NewsItemModel
    {
        public Guid IDNewsItem { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Tags { get; set; }
    }
}