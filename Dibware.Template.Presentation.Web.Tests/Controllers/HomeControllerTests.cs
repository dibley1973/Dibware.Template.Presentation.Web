using Dibware.Template.Presentation.Web.Controllers;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Tests.Helpers;
using Dibware.Template.Presentation.Web.Tests.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        #region Initialisation

        /// <summary>
        /// Setups the home controller.
        /// </summary>
        /// <returns></returns>
        private static HomeController SetupHomeController(String[] roles)
        {
            var controller =
                ControllerHelper.SetUpController<HomeController>(roles);
            return controller;
        }

        #endregion Initialisation

        #region About

        [TestMethod]
        public void Test_AboutAction_ReturnsAboutView()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var expectedResultType = typeof(ViewResult);
            const String expectedViewName = "About";

            // Act
            var result = controller.About();

            // Assert
            Assert.IsInstanceOfType(result, expectedResultType);
            Assert.AreEqual(expectedViewName, ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void Test_AboutAction_IsNotDecoratedWithAuthorizeAttribute()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(AboutViewModel);
            var attributeType = typeof(AuthorizeAttribute);
            const String actionMethodName = "About";

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        [TestMethod]
        public void Test_AboutAction_IsNotDecoratedWithWebsiteAuthorizeAttribute()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(AboutViewModel);
            var attributeType = typeof(WebsiteAuthorizeAttribute);
            const String actionMethodName = "About";

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        #endregion About

        #region Index

        [TestMethod]
        public void Test_IndexAction_ReturnsIndexView()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var expectedResultType = typeof(ViewResult);
            const String expectedViewName = "Index";

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, expectedResultType);
            Assert.AreEqual(expectedViewName, ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void Test_IndexAction_IsNotDecoratedWithAuthorizeAttribute()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(IndexViewModel);
            var attributeType = typeof(AuthorizeAttribute);
            const String actionMethodName = "Index";

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        [TestMethod]
        public void Test_IndexAction_IsNotDecoratedWithWebsiteAuthorizeAttribute()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(IndexViewModel);
            var attributeType = typeof(WebsiteAuthorizeAttribute);
            const String actionMethodName = "Index";

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        #endregion Index
    }
}