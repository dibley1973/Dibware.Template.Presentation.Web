using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Dibware.Template.Presentation.Web.Tests.App_Start
{
    // Ref:
    //  http://www.strathweb.com/2012/08/testing-routes-in-asp-net-web-api/
    //
    //  https://github.com/AnthonySteele/MvcRouteTester // Possibly better example

    /// <summary>
    /// Tests for Routes config
    /// </summary>
    [TestClass]
    public class RouteConfigTests
    {
        #region Declarations

        private HttpConfiguration _config;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            _config = new HttpConfiguration
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
            };
            _config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        #endregion

        #region Tests

        #region RegisterRoutes

        [TestMethod]
        public void Test_RegisterRoutes_CheckCorrectCount()
        {
            // Arrange
            const Int32 expectedCollectionCount = 2;
            var routeCollection = new RouteCollection();

            // Act
            RouteConfig.RegisterRoutes(routeCollection);

            // Assert
            Assert.AreEqual(expectedCollectionCount, routeCollection.Count);
        }

        [TestMethod]
        public void Test_RegisterRoutes_ReturnsCorrectRouteType()
        {
            // Arrange
            const String expectedRoute0TypeName = "System.Web.Mvc.RouteCollectionExtensions+IgnoreRouteInternal";
            const String expectedRoute1TypeName = "LowercaseRoutesMVC.LowercaseRoute";
            var routeCollection = new RouteCollection();

            // Act
            RouteConfig.RegisterRoutes(routeCollection);

            // Assert
            Assert.AreEqual(expectedRoute0TypeName, routeCollection[0].GetType().ToString());
            Assert.AreEqual(expectedRoute1TypeName, routeCollection[1].GetType().ToString());
        }

        #endregion

        #region Routes

        [TestMethod]
        public void Test_DefaultRoute_ReturnsIndexActionOnHomeController()
        {
            // Arrange
            var mockRouteContextBase = new Mock<HttpContextBase>();
            mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(mockRouteContextBase.Object);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);    // Watch casing!
            Assert.AreEqual("Index", routeData.Values["action"]);       // Watch casing!
        }

        [TestMethod]
        public void Test_RouteDataForHomeIndex_ReturnsIndexActionOnHomeController()
        {
            // Arrange
            var mockRouteContextBase = new Mock<HttpContextBase>();
            mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/home/index");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(mockRouteContextBase.Object);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("home", routeData.Values["controller"]);
            Assert.AreEqual("index", routeData.Values["action"]);
        }

        #endregion

        #endregion
    }
}