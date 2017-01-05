using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolunteerTrack.Controllers;
using System.Web.Mvc;

namespace VolunteerTrack.Tests.DAL
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InputActivity()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.InputActivity() as ViewResult;

            // Assert
            Assert.AreEqual("Enter your activity information here.", result.ViewBag.Message);
        }
        [TestMethod]
        public void MyActivities()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.MyActivities() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
