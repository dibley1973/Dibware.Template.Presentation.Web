using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Tests.Mocks;
using Dibware.Web.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Principal;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Tests.Filters
{
    [TestClass]
    public class WebsiteAuthorizeAttributeTests
    {
        #region Private Members

        private WebIdentity _webIdentity;
        private Mock<WebsitePrincipal> _userPrincipalMock;
        private Mock<IApplicationConfiguration> _appConfigurationMock;
        private Mock<AuthorizationContext> _authorizationContextMock;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Setup role configuration
            _appConfigurationMock = new Mock<IApplicationConfiguration>();
            _appConfigurationMock.SetupGet(c => c.AdministratorUserRoleName).Returns("AdministratorUser");
            _appConfigurationMock.SetupGet(c => c.SuperUserRoleName).Returns("SuperUser");
            _appConfigurationMock.SetupGet(c => c.MainUserRoleName).Returns("MainUser");
            _appConfigurationMock.SetupGet(c => c.UnknownUserRoleName).Returns("UnknownUser");

            // Setup auth context
            _authorizationContextMock = new Mock<AuthorizationContext>();
        }

        /// <summary>
        /// Setups the stock integrator authorize attribute.
        /// </summary>
        /// <param name="userRole">The user role.</param>
        /// <returns></returns>
        private static WebsiteAuthorizeAttribute SetupWebsiteAuthorizeAttribute(UserRole userRole)
        {
            var attribute = new WebsiteAuthorizeAttribute(userRole);
            //attribute.AppConfiguration = _appConfigurationMock.Object;
            return attribute;
        }

        /// <summary>
        /// Setups the stock integrator authorize attribute.
        /// </summary>
        /// <param name="userRole">The user role.</param>
        /// <returns></returns>
        private MockWebsiteAuthorizeAttribute SetupMockWebsiteAuthorizeAttribute(UserRole userRole)
        {
            var attribute = new MockWebsiteAuthorizeAttribute(userRole);
            return attribute;
        }

        /// <summary>
        /// Setups the name of the user principalwith role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="identityIsAuthenticated">if set to <c>true</c> if identity is authenticated.</param>
        private void SetupUserPrincipalwithRoleName(String roleName, Boolean identityIsAuthenticated = true)
        {
            // Setup mock principle
            var roles = new[] { roleName };
            _webIdentity = new WebIdentity(WindowsIdentity.GetCurrent(), roles);
            _userPrincipalMock = new Mock<WebsitePrincipal>(_webIdentity);
            _userPrincipalMock.SetupGet(p => p.Identity.IsAuthenticated).Returns(identityIsAuthenticated);

            _authorizationContextMock.Setup(ac => ac.HttpContext.User).Returns(_userPrincipalMock.Object);
        }

        #endregion

        #region Tests

        #region Authorising With Null Context

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebsiteAuthorizeAttribute_WithNullAuthorizationContext_ThrowsArgumentNullException()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.OnAuthorization(null);

            // Assert
            // Should not get here due to Exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebsiteAuthorizeAttribute_WithNullHttpContext_ThrowsArgumentNullException()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupMockWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.AuthorizeCore(null);

            // Assert
            // Should not get here due to Exception
        }

        #endregion

        #region AuthorisingAsAdmin

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsAdminUserAndAuthorisingAsAdmin_ResultsInAccessGranted()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsNull(_authorizationContextMock.Object.Result);
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsSuperUserAndAuthorisingAsAdmin_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.SuperUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsMainUserAndAuthorisingAsAdmin_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.MainUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsUnknownUserAndAuthorisingAsAdmin_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.UnknownUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.AdministratorUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        #endregion

        #region AuthorisingAsSuperUser

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsAdminUserAndAuthorisingAsSuperUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.SuperUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsSuperUserAndAuthorisingAsSuperUser_ResultsInAccessGranted()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.SuperUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.SuperUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsNull(_authorizationContextMock.Object.Result);
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsMainUserAndAuthorisingAsSuperUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.MainUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.SuperUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsUnknownUserAndAuthorisingAsSuperUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.UnknownUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.SuperUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        #endregion

        #region AuthorisingAsMainUser

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsAdminUserAndAuthorisingAsMainUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.MainUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsSuperUserAndAuthorisingAsMainUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.SuperUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.MainUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsMainUserAndAuthorisingAsMainUser_ResultsInAccessGranted()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.MainUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.MainUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsNull(_authorizationContextMock.Object.Result);
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsUnknownUserAndAuthorisingAsMainUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.UnknownUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.MainUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        #endregion

        #region AuthorisingAsUnknownUser

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsAdminUserAndAuthorisingAsUnknownUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.UnknownUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsSuperUserAndAuthorisingAsUnknownUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.SuperUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.UnknownUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsMainUserAndAuthorisingAsUnknownUser_ResultsInAccessDenied()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.MainUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.UnknownUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));
        }

        [TestMethod]
        public void Test_WebsiteAuthorizeAttribute_UserIsUnknownUserAndAuthorisingAsUnknownUser_ResultsInAccessGranted()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.UnknownUserRoleName);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.UnknownUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsNull(_authorizationContextMock.Object.Result);
        }

        #endregion

        #region Identity Not IsAuthenticated

        [TestMethod]
        public void Test_IdentityIsNotAuthenticated()
        {
            // Arrange
            SetupUserPrincipalwithRoleName(_appConfigurationMock.Object.AdministratorUserRoleName, false);
            var attribute = SetupWebsiteAuthorizeAttribute(UserRole.UnknownUser);

            // Act
            attribute.OnAuthorization(_authorizationContextMock.Object);

            // Assert
            Assert.IsTrue(_authorizationContextMock.Object.Result.GetType() == typeof(HttpUnauthorizedResult));

        }

        #endregion

        #endregion
    }
}
