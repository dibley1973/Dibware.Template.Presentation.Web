using Dibware.Template.Presentation.Web.Controllers;
using Dibware.Template.Presentation.Web.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net.Http;
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

        //private HttpContextBase _mockRouteContextBase;
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

            //var _mockRouteContextBase =(new Mock<HttpContextBase>(MockBehavior.Strict)).Object;
            //var httpContext = new Rou()

            //this._mockBundleContext = new BundleContext(mockContext, new BundleCollection(), String.Empty);

            //BundleTable.EnableOptimizations = true;

            // Mock mapping a bundle item's virtual path to a physical path
            //BundleTable.MapPathMethod = MapBundleItemPath;
        }

        #endregion

        #region Tests

        #region RegisterRoutes

        [Ignore]
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

        [Ignore]
        [TestMethod]
        public void Test_RegisterRoutes_CheckCorrectType()
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

        [Ignore]
        [TestMethod]
        public void Test_HomeController_IndexIsCorrect()
        {
            // fails but almost there!
            // Ref:
            //  http://www.strathweb.com/2012/08/testing-routes-in-asp-net-web-api/

            var request = new HttpRequestMessage(HttpMethod.Get, "http://server/Home/Index");
            var routeTester = new RouteTester(_config, request);

            Assert.AreEqual(typeof(HomeController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((HomeController c) => c.Index()), routeTester.GetActionName());
        }

        [Ignore]
        [TestMethod]
        public void Test_RouteHasDefaultActionWhenUrlWithoutAction()
        {
            // Arrange
            var mockRouteContextBase = new Mock<HttpContextBase>();
            mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");
            //mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
            //.Returns(url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(mockRouteContextBase.Object);

            // Assert
            Assert.IsNotNull(routeData);
        }

        [Ignore]
        [TestMethod]
        public void Test_Route_HomeIndex()
        {
            // Arrange
            var mockRouteContextBase = new Mock<HttpContextBase>();
            mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/home.index");
            //mockRouteContextBase.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
            //.Returns(url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(mockRouteContextBase.Object);

            // Assert
            Assert.IsNotNull(routeData);
        }

        #endregion
    }
}