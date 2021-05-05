using ADLVMusicAcademy.Controllers;
using ADLVMusicAcademy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ADLVMusicAcademy.Tests.Controllers
{
    [TestClass]
    public class SubscriptionControllerTest
    {
        [TestMethod]
        public void Index(string sortOrder, string searchString)
        {
            // Arrange
            SubscriptionController controller = new SubscriptionController();

            // Act
            ViewResult result = controller.Index(string sortOrder, string searchString) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
