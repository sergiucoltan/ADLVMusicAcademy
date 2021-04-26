using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class SubscriptionTypeModel
    {
        public int IDSubscriptionType { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public string SubscriptionTypeName { get; set; }
    }
}