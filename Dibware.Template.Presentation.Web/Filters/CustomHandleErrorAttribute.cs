using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Error;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    public sealed class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest() &&
                !filterContext.ExceptionHandled)
            {
                // Create error model
                var model = new ErrorViewModel
                {
                    Exception = filterContext.Exception
                };

                // Fill that base view model with some data
                var controller = (BaseController)filterContext.Controller;
                controller.FillBaseViewModel(model);

                // Set the view name
                model.PageTitle = "Error";

                // Set the result
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<ErrorViewModel>(model)
                };

                // Configure the response object
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}