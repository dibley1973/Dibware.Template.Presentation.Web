using Dibware.Template.Presentation.Web.Filters;
using Dibware.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Tests.Filters
{
    [TestClass]
    public class CompressAttributeTest
    {
        #region Private Members

        private Mock<ActionExecutingContext> _actionExecutingContextMock;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/a", UriKind.Absolute));
            request.SetupGet(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());

            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            response.Setup(x => x.ApplyAppPathModifier("/post1")).Returns("http://localhost/post1");

            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);

            // Setup action executing context
            _actionExecutingContextMock = new Mock<ActionExecutingContext>();
            _actionExecutingContextMock.Setup(aec => aec.HttpContext).Returns(context.Object);


        }

        #endregion

        #region Tests

        [Ignore]
        [TestMethod]
        public void Test_AcceptedEncodingIsNone_ResultsIn_NoCompression()
        {

            //    // Arrange
            //    var httpContext = new Mock<HttpContextBase>();
            //    var winIdentity = new Mock<IIdentity>();
            //    winIdentity.Setup(i => i.IsAuthenticated).Returns(() => true);
            //    winIdentity.Setup(i => i.Name).Returns(() => "WHEEEE");
            //    //httpContext.SetupGet(c => c.User).Returns(() => new ImdPrincipal(winIdentity.Object)); // This is my implementation of IIdentity
            //    var requestBase = new Mock<HttpRequestBase>();
            //    var headers = new NameValueCollection
            //{
            //   {"Special-Header-Name", "false"}
            //};
            //    requestBase.Setup(x => x.Headers).Returns(headers);
            //    requestBase.Setup(x => x.HttpMethod).Returns("GET");
            //    requestBase.Setup(x => x.Url).Returns(new Uri("http://localhost/"));
            //    requestBase.Setup(x => x.RawUrl).Returns("~/Maintenance/UnExistingMaster");
            //    requestBase.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(() => "~/Maintenance/UnExistingMaster");
            //    requestBase.Setup(x => x.IsAuthenticated).Returns(() => true);
            //    httpContext.Setup(x => x.Request).Returns(requestBase.Object);
            //    var controller = new Mock<ControllerBase>();
            //    var actionDescriptor = new Mock<ActionDescriptor>();
            //    var controllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller.Object);

            //// Arrange
            //var builder = new TestControllerBuilder();
            //var controller = new CurrenciesController(this._currencyServiceMock.Object);
            //builder.InitializeController(controller);

            //ControllerContext controllerContext = Mock<ControllerContext(new Mock().Object, new RouteData(), new Mock().Object);
            //ActionExecutingContext filterContext = new ActionExecutingContext(controllerContext, new RouteValueDictionary());
            //var attribute = this.SetupCompressAttribute();


            //// Act
            //attribute.OnActionExecuting(filterContext);

            // Assert
            // Assert.AreEqual("bar", filterContext.Result.ToString()); 
            // .Controller.ViewData["foo"]);


            // Act
            //var filterContext = controllerContext. new ActionExecutingContext(); //controllerContext, actionDescriptor.Object);
            //attribute.OnActionExecuting(controllerContext.RequestContext);

            //    // Assert
            //    Assert.AreEqual("", filterContext.HttpContext.Response);

            //// Arrange
            //var attribute = this.SetupCompressAttribute();
            ////var originalLength = _actionExecutingContextMock.Object.HttpContext.Response.OutputStream.Length;

            //// Act
            //attribute.OnActionExecuting(_actionExecutingContextMock.Object);
            //var newlength = _actionExecutingContextMock.Object.HttpContext.Response.OutputStream.Length;

            //// Assert
            //Assert.IsNull(_actionExecutingContextMock.Object.Result);
            ////Assert.AreEqual(originalLength, newlength);
        }

        #endregion

        #region Methods : Private

        #endregion
    }
}