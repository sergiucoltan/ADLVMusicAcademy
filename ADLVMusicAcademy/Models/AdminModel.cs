using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models

{
    public class AdminModel
    {
        public Guid IDAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
    }
}