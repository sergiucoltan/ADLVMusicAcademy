using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class SubscriptionModel
    {
        public Guid IDSubscription { get; set; }
        public Guid IDCourse { get; set; }
        public Guid IDStudent { get; set; }
        public Guid IDTeacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}