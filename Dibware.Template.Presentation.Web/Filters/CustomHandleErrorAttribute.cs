using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Error;
using Ninject;
using System;
using System.Web;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    public sealed class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Gets or sets the error service.
        /// </summary>
        /// <value>
        /// The error service.
        /// </value>
        [Inject]
        public IErrorService ErrorService { get; set; }

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The action-filter context.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest() &&
                !filterContext.ExceptionHandled)
            {
                // Capture details we are interested in
                var username = (String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ?
                    "Guest" :
                    HttpContext.Current.User.Identity.Name);
                var exception = filterContext.Exception;

                // Log the error
                LogException(exception, username);

                // Create error model
                var model = new ErrorViewModel
                {
                    Exception = exception
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

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="username">The username.</param>
        private void LogException(Exception exception, string username)
        {
            try
            {
                if (ErrorService != null)
                {
                    ErrorService.LogException(exception, username);
                }
            }
            //catch (Exception) {}  // fail gracefully
            finally { }
        }
    }
}