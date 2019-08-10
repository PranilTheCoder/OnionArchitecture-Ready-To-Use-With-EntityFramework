using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PranilArchitecture;
using PranilArchitecture.Controllers;
using PranilArchitecture.Service;

namespace PranilArchitecture.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        
        [TestMethod]
        public void Index()
        {
            var mockRepo = new Mock<IExpenseTypeService>();
            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            var mockRepo = new Mock<IExpenseTypeService>();
            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            var mockRepo = new Mock<IExpenseTypeService>();
            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
