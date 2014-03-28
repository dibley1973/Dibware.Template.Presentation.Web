using Dibware.Template.Presentation.Web.Modules.UserPreferences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dibware.Template.Presentation.Web.Tests.Modules.UserPreferences
{
    [TestClass]
    public class UserPreferenceTests
    {
        #region Tests

        [TestMethod]
        public void Test_UserPreference_SetCustomTheme_ResultsIn_CorrectThemeReturned()
        {
            // Arrange
            const String expectedTheme = "TestTheme";
            var userPreferenceSettings = (IUserPreferenceData)new UserPreferenceData();

            // Act
            userPreferenceSettings.CustomTheme = expectedTheme;

            // Assert
            Assert.AreEqual(expectedTheme, userPreferenceSettings.CustomTheme);
        }

        #endregion
    }
}