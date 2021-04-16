using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class SubscriptionModel
    {
        public Guid IDSubscription { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDCourse { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDStudent { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}