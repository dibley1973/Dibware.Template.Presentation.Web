using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Base;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dibware.Template.Presentation.Web.Tests.Controllers.Base
{
    [TestClass]
    public class BaseContollerTests
    {
        #region Initialisation

        /// <summary>
        /// Setups the Base controller.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        private static BaseController SetupBaseController(String[] roles)
        {
            var controller =
                ControllerHelper.SetUpController<BaseController>(roles);
            return controller;
        }

        #endregion Initialisation

        #region MetaTag Tests

        [TestMethod]
        public void Test_BaseController_FillsCommonMetaTagDataFromResourceFile()
        {
            // Arrange
            var roles = new[] { UserRole.AdministratorUser.ToString(), UserRole.MainUser.ToString() };
            var controller = SetupBaseController(roles);

            var model = new BaseViewModel();
            var expectedAuthor = MetaTagData.Author;
            var expectedDescription = MetaTagData.Description;

            // Act
            controller.FillBaseViewModel(model);

            // Assert
            Assert.AreEqual(expectedAuthor, model.MetaAuthor);
            Assert.AreEqual(expectedDescription, model.MetaDescription);
        }

        #endregion

        #region Brand Name Tests

        [TestMethod]
        public void Test_BaseController_FillsBaseViewModelWithBrandName_CorrectBrandNameReturned()
        {
            // Arrange
            const String expectedBrandName = "TestBrand";
            var roles = new[] { UserRole.MainUser.ToString() };
            var controller = SetupBaseController(roles);
            var model = new BaseViewModel();

            // Act
            controller.FillBaseViewModel(model);

            // Assert
            Assert.AreEqual(expectedBrandName, model.BrandName);
        }

        #endregion

        #region Custom Colour Theme Tests

        [TestMethod]
        public void Test_BaseController_FillsBaseViewModelWithKnownCustomTheme_CorrectThemeReturned()
        {
            // Arrange
            const String expectedTheme = AssetPaths.Themes.Grey.Name;
            var roles = new[] { UserRole.MainUser.ToString() };
            var controller = SetupBaseController(roles);
            var model = new BaseViewModel
            {
                CustomColourTheme = expectedTheme
            };

            // Act
            controller.FillBaseViewModel(model);

            // Assert
            Assert.AreEqual(expectedTheme, model.CustomColourTheme);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BaseController_FillsBaseViewModelWithUnKnownCustomTheme_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var roles = new[] { UserRole.MainUser.ToString() };
            var controller = SetupBaseController(roles);
            var model = new BaseViewModel
            {
                CustomColourTheme = "No Known Theme"
            };

            // Act
            controller.FillBaseViewModel(model);

            // Assert
            // Exception should be thrown
        }

        #endregion
    }
}
