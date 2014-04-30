using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Tests.Resources;
using Dibware.Web.Security.Principal;
using Moq;
using MvcContrib.TestHelper;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dibware.Template.Presentation.Web.Tests.Helpers
{
    public static class ControllerHelper
    {
        /// <summary>
        /// Sets up controller, of type T.
        /// </summary>
        /// <typeparam name="T">The type of controller to set up</typeparam>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static T SetUpController<T>(String[] roles) where T : class
        {
            // Validate specified type derives from System.Web.Mvc.Controller
            var controllerType = typeof(T);
            var typeOfController = typeof(Controller);
            if (!typeOfController.IsAssignableFrom(controllerType))
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.TypeMustDerviceFromcontroller);
            }

            // Now create the controller
            var builder = new TestControllerBuilder();
            T controller;
            if (controllerType.IsSubclassOf(typeof(BaseControllerWithDataLookup)))
            {
                Mock<ILookupService> lookupServiceMock = MockServiceHelper.GetLookupServiceMock();
                controller = (T)Activator.CreateInstance(controllerType, lookupServiceMock.Object);
            }
            else
            {
                controller = (T)Activator.CreateInstance(controllerType);
            }

            //var controller = (T)Activator.CreateInstance(controllerType);
            builder.InitializeController(controller as Controller);

            // Mock user principal
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity);
            var appConfigurationMock = new Mock<IApplicationConfiguration>();
            appConfigurationMock.Setup(ac => ac.BrandName).Returns("TestBrand");
            principal.ApplicationConfiguration = appConfigurationMock.Object;

            // Mock http context and create controller context
            var context = new Mock<HttpContextBase>();
            context.SetupGet(c => c.User).Returns(principal);
            if (controller is Controller)
            {
                (controller as Controller).ControllerContext = new ControllerContext(context.Object, new RouteData(), controller as Controller);
            }

            // Return the controller
            return controller;
        }
    }
}
