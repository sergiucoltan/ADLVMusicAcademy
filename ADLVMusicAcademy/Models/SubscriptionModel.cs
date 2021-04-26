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

        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDCourse { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDStudent { get; set; }

        [DisplayName("Subscription Type")]
        public int IDSubscriptionType { get; set; }

        
        public string SubscriptionTypeName { get; set; }

        [DisplayName("Student First Name")]
        public string StudentFirstName { get; set; }

        [DisplayName("Student Last Name")]
        public string StudentLastName { get; set; }


        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

    }

}