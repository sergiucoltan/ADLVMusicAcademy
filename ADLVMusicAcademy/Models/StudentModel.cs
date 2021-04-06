using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVMusicAcademy.Models
{
    public class StudentModel
    {
        public Guid IDStudent { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

    }
}