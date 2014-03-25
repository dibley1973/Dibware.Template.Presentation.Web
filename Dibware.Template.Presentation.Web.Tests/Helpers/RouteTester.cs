using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;

namespace Dibware.Template.Presentation.Web.Tests.Helpers
{
    public class RouteTester
    {
        readonly HttpRequestMessage _request;
        readonly IHttpControllerSelector _controllerSelector;
        readonly HttpControllerContext _controllerContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteTester"/> class.
        /// </summary>
        /// <param name="conf">The conf.</param>
        /// <param name="req">The req.</param>
        public RouteTester(HttpConfiguration conf, HttpRequestMessage req)
        {
            _request = req;
            var config = conf;
            var routeData = config.Routes.GetRouteData(_request);
            _request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
            _controllerSelector = new DefaultHttpControllerSelector(config);
            _controllerContext = new HttpControllerContext(config, routeData, _request);
        }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <returns></returns>
        public string GetActionName()
        {
            if (_controllerContext.ControllerDescriptor == null)
            {
                GetControllerType();
            }
            var actionSelector = new ApiControllerActionSelector();
            var descriptor = actionSelector.SelectAction(_controllerContext);

            return descriptor.ActionName;
        }

        /// <summary>
        /// Gets the type of the controller.
        /// </summary>
        /// <returns></returns>
        public Type GetControllerType()
        {
            var descriptor = _controllerSelector.SelectController(_request);
            _controllerContext.ControllerDescriptor = descriptor;
            return descriptor.ControllerType;
        }
    }
}