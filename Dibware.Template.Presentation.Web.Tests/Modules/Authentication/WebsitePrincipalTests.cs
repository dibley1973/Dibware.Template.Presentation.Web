using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Modules.UserPreferences;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Web.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Dibware.Helpers;

namespace Dibware.Template.Presentation.Web.Tests.Modules.Authentication
{
    [TestClass]
    public class WebsitePrincipalTests
    {
        #region Reference

        // Mock IPrincipal / IIdentity object that can be used for unit testing security.
        //  https://gist.github.com/jwcarroll/1708922

        #endregion

        #region Private Members

        private Mock<IApplicationConfiguration> _appConfigurationMock;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Setup application configuration
            _appConfigurationMock = new Mock<IApplicationConfiguration>();
        }

        /// <summary>
        /// Adds the rolenames to mock configuration.
        /// </summary>
        /// <param name="appConfigurationMock">The application configuration mock object.</param>
        private static void AddRolenamesToMockConfiguration(Mock<IApplicationConfiguration> appConfigurationMock)
        {
            appConfigurationMock.SetupGet(c => c.AdministratorUserRoleName).Returns(UserRole.AdministratorUser.ToString);
            appConfigurationMock.SetupGet(c => c.MainUserRoleName).Returns(UserRole.MainUser.ToString);
            appConfigurationMock.SetupGet(c => c.UnknownUserRoleName).Returns(UserRole.UnknownUser.ToString);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Test_CliquePrincipal_InstantiateAndCheckName_ReturnsCorrectName()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            Dibware.Helpers.Validation.Guard.ArgumentIsNotNull(identity, "identity");
            var expectedName = identity.Name;
            var webIdentity = new WebIdentity(identity, roles);

            // Act
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };
            var name = principal.Name;

            // Assert
            Assert.AreEqual(expectedName, name);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsAdminWhenNotInRole_ResultsInFalse()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isAdminUser = principal.IsAdministratorUser;

            // Assert
            Assert.IsFalse(isAdminUser);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsAdminWhenIsInRole_ResultsInTrue()
        {
            // Arrange
            AddRolenamesToMockConfiguration(_appConfigurationMock);
            var roles = new[] { UserRole.AdministratorUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isAdminUser = principal.IsAdministratorUser;

            // Assert
            Assert.IsTrue(isAdminUser);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsMainWhenNotInMainRole_ResultsInFalse()
        {
            // Arrange
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isPrivateUser = principal.IsMainUser;

            // Assert
            Assert.IsFalse(isPrivateUser);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsMainWhenIsInMainRole_ResultsInTrue()
        {
            // Arrange
            AddRolenamesToMockConfiguration(_appConfigurationMock);
            var roles = new[] { UserRole.MainUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isPrivateUser = principal.IsMainUser;

            // Assert
            Assert.IsTrue(isPrivateUser);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsUnknownWhenNotInRole_ResultsInFalse()
        {
            // Arrange
            var roles = new[] { UserRole.MainUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isUnknownUser = principal.IsUnknownUser;

            // Assert
            Assert.IsFalse(isUnknownUser);
        }

        [TestMethod]
        public void Test_CliquePrincipal_IsUnknownWhenIsInRole_ResultsInTrue()
        {
            // Arrange
            AddRolenamesToMockConfiguration(_appConfigurationMock);
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };

            // Act
            var isUnknownUser = principal.IsUnknownUser;

            // Assert
            Assert.IsTrue(isUnknownUser);
        }

        [TestMethod]
        public void Test_CliquePrinciple_SetUserPreferences_GetCorrect()
        {

            // Arrange
            //AddRolenamesToMockConfiguration(_appConfigurationMock);
            var roles = new[] { UserRole.UnknownUser.ToString() };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _appConfigurationMock.Object
            };
            var expectedUserPreferences = (IUserPreferenceData)new UserPreferenceData();
            principal.UserPreferences = expectedUserPreferences;

            // Act
            var userPreferences = principal.UserPreferences;

            // Assert
            Assert.AreEqual(expectedUserPreferences, userPreferences);
        }

        #endregion
    }
}