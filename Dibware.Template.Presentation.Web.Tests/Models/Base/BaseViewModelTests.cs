using Dibware.Template.Presentation.Web.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dibware.Template.Presentation.Web.Tests.Models.Base
{
    [TestClass]
    public class BaseViewModelTests
    {
        [TestMethod]
        public void Test_CustomColourTheme_ReturnsSetValue()
        {
            // Arrange
            var model = new MockBaseViewModel();
            const String expectedValue = "Green";

            // Act
            model.CustomColourTheme = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.CustomColourTheme);
        }

        [TestMethod]
        public void Test_HasCustomColourTheme_ReturnsFalse_WhenCustomColourThemeNotSet()
        {
            // Arrange
            var model = new MockBaseViewModel();
            const Boolean expectedValue = false;

            // Act

            // Assert
            Assert.AreEqual(expectedValue, model.HasCustomColourTheme);

        }

        [TestMethod]
        public void Test_HasCustomColourTheme_ReturnsTrue_WhenCustomColourThemeIsSet()
        {
            // Arrange
            var model = new MockBaseViewModel();
            const String customColourTheme = "Green";
            const Boolean expectedValue = true;

            // Act
            model.CustomColourTheme = customColourTheme;

            // Assert
            Assert.AreEqual(expectedValue, model.HasCustomColourTheme);
        }
    }
}
