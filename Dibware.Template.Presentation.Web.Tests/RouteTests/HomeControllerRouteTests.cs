using Dibware.Template.Presentation.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dibware.Template.Presentation.Web.Tests.RouteTests
{
    /// <summary>
    /// Tests routes for the HomeController
    /// </summary>
    [TestClass]
    public class HomeControllerRouteTests
    {
        #region Declarations

        private RouteCollection _routes;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            _routes = new RouteCollection();
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            _routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = 32 });
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Test_DefaultRoute_ShouldMapToHomeControllerIndexAction()
        {
            // Arrange, Act, Assert
            _routes.ShouldMap("/").To<HomeController>(x => x.Index());
        }

        [TestMethod]
        public void Test_HomeControllerAboutRoute_ShouldMapToHomeControllerIndexAbout()
        {
            // Arrange, Act, Assert
            _routes.ShouldMap("/home/about").To<HomeController>(x => x.About());
        }

        [TestMethod]
        public void Test_HomeControllerIndexRoute_ShouldMapToHomeControllerIndexAction()
        {
            // Arrange, Act, Assert
            _routes.ShouldMap("/home/index").To<HomeController>(x => x.Index());
        }

        [TestMethod]
        [ExpectedException(typeof(MvcRouteTester.Assertions.AssertionException))]
        public void Test_HomeControllerInvalidRoute_ThrowsException()
        {
            // Arrange, Act, Assert
            _routes.ShouldMap("/home/banana").To<HomeController>(x => x.Index());
        }

        #endregion
    }
}