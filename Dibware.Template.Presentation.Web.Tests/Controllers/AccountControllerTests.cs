using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dibware.Template.Presentation.Web.Controllers;
using Dibware.Template.Presentation.Web.Tests.Helpers;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Models.Account;
using Dibware.Template.Presentation.Web.Modules.Authentication;

using System.Linq;
using System.Web.Mvc;
using Dibware.Template.Presentation.Web.Tests.Resources;

namespace Dibware.Template.Presentation.Web.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        #region Initialisation

        /// <summary>
        /// Setups the home controller.
        /// </summary>
        /// <returns></returns>
        private static AccountController SetupHomeController(String[] roles)
        {
            var controller =
                ControllerHelper.SetUpController<AccountController>(roles);
            return controller;
        }

        #endregion Initialisation

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
        public void Test_IndexAction_IsDecoratedWithAuthorizeAttribute()
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
            Assert.IsTrue(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        [TestMethod]
        public void Test_IndexAction_IsDecoratedWithWebsiteAuthorizeAttribute()
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
            Assert.IsTrue(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        #endregion Index

        #region Login

        [TestMethod]
        public void Test_LoginAction_ReturnsLoginView()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var expectedResultType = typeof(ViewResult);
            const String returnUrl = "~/home/index";
            const String expectedViewName = "Login";

            // Act
            var result = controller.Login(returnUrl);

            // Assert
            Assert.IsInstanceOfType(result, expectedResultType);
            Assert.AreEqual(expectedViewName, ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void Test_LoginAction_IsNotDecoratedWithAuthorizeAttribute()
        {
            // Arrange
            const String actionMethodName = "Login";
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(LoginViewModel);
            var attributeType = typeof(AuthorizeAttribute);
            Type[] parameterTypes = { typeof(String) };

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName, parameterTypes);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        [TestMethod]
        public void Test_LoginAction_IsNotDecoratedWithWebsiteAuthorizeAttribute()
        {
            // Arrange
            const String actionMethodName = "Login";
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(LoginViewModel);
            var attributeType = typeof(WebsiteAuthorizeAttribute);
            Type[] parameterTypes = { typeof(String) };

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName, parameterTypes);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        #endregion Login

        #region Register

        [TestMethod]
        public void Test_RegisterAction_ReturnsRegisterView()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var expectedResultType = typeof(ViewResult);
            const String expectedViewName = "Register";

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsInstanceOfType(result, expectedResultType);
            Assert.AreEqual(expectedViewName, ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void Test_RegisterAction_IsNotDecoratedWithAuthorizeAttribute()
        {
            // Arrange
            const String actionMethodName = "Register";
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(RegisterViewModel);
            var attributeType = typeof(AuthorizeAttribute);
            Type[] parameterTypes = { typeof(String) };

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName, parameterTypes);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        [TestMethod]
        public void Test_RegisterAction_IsNotDecoratedWithWebsiteAuthorizeAttribute()
        {
            // Arrange
            const String actionMethodName = "Register";
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var controller = SetupHomeController(roles);
            var controllerType = controller.GetType();
            var viewModelType = typeof(RegisterViewModel);
            var attributeType = typeof(WebsiteAuthorizeAttribute);
            Type[] parameterTypes = { typeof(String) };

            // Act
            var methodInfo = controllerType.GetMethod(actionMethodName, parameterTypes);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            // Assert
            Assert.IsFalse(attributes.Any(),
                String.Format(FailedTestMessages.AttributeFoundOnActionMethod,
                attributeType,
                actionMethodName,
                viewModelType));
        }

        #endregion Register


    }
}
