using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;

namespace Dibware.Template.Presentation.Web.Tests.App_Start
{
    /// <summary>
    /// Tests for WebApi config
    /// </summary>
    [TestClass]
    public class WebApiConfigTests
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
            //_config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
            //_config.Routes.MapHttpRoute(name: "DefaultRPC", routeTemplate: "api/v2/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
            //_config.Routes.MapHttpRoute(name: "DefaultRPC", routeTemplate: "api/v2/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
        }

        #endregion

        #region Tests

        #region RegisterRoutes

        [TestMethod]
        public void Test_RegisterConfig_CheckCorrectCount()
        {
            // Arrange
            const Int32 expectedCollectionCount = 1;
            var config = new HttpConfiguration();

            // Act
            WebApiConfig.Register(config);

            // Assert
            Assert.AreEqual(expectedCollectionCount, config.Routes.Count);
        }

        #endregion

        [Ignore]    // TODO: Implement if we get any WebApi controllers
        [TestMethod]
        public void UrlControllerGetIsCorrect()
        {
            //var request = new HttpRequestMessage(HttpMethod.Get, "http://www.strathweb.com/api/url/");
            //var routeTester = new RouteTester(_config, request);

            //Assert.AreEqual(typeof(MyApiController), routeTester.GetControllerType());
            //Assert.AreEqual(ReflectionHelpers.GetMethodName((MyApiController c) => c.ActionMethod()), routeTester.GetActionName());
        }

        #endregion
    }
}