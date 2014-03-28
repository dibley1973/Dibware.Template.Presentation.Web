using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dibware.Template.Presentation.Web.Tests.Filters
{
    [TestClass]
    public class ManageBaseViewModelAttributeTest
    {
        #region Tests

        [Ignore]    // TODO: Need to get some tests in...
        [TestMethod]
        public void Test_OnActionExecuted_FillsBaseViewModel()
        {
            //// Arrange
            //var filterContextMock = new Mock<ActionExecutedContext>();
            //var routeData = new RouteData();
            //routeData.Values["controller"] = "Home";
            //routeData.Values["action"] = "Index";
            //var controller = new HomeController();
            //var httpContextMock = new Mock<HttpContextBase>();
            //var requestContext = new RequestContext(httpContextMock.Object, routeData);
            //var viewResult = new ViewResult();
            //controller.ControllerContext = new ControllerContext(requestContext, controller);
            //filterContextMock.Setup(f => f.RouteData).Returns(routeData);
            //filterContextMock.Setup(f => f.Controller).Returns(controller);
            ////filterContextMock.Setup(f => f.Result).Returns(viewResult);
            //var filter = new ManageBaseViewModelAttribute();

            //// Act
            //filter.OnActionExecuted(filterContextMock.Object);
            //ViewResult result = filterContextMock.Object.Result as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Error", result.ViewName);
            //Assert.AreEqual("Some Data", controller.ViewData["data"]);
        }

        #endregion

    }
}
