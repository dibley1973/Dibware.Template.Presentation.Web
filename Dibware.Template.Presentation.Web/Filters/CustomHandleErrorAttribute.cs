using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Error;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        //private IErrorService _errorService = null;

        /// <summary>
        /// Gets the error service.
        /// </summary>
        /// <value>
        /// The error service.
        /// </value>
        //[Inject]
        public IErrorService ErrorService { get; private set; }
        //{
        //    get { return _errorService; }
        //    set { _errorService = value; }
        //}

        /// <summary>
        /// Gets a value indicating whether to show detailed error messages.
        /// </summary>
        /// <value>
        /// <c>true</c> if to show detailed error messages; otherwise, <c>false</c>.
        /// </value>
        public Boolean ShowDetailedErrorMessages { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHandleErrorAttribute"/> class.
        /// </summary>
        /// <param name="errorService">The error service.</param>
        /// <param name="showDetailedErrorMessages">if set to <c>true</c> [show detailed error messages].</param>
        public CustomHandleErrorAttribute(
            IErrorService errorService,
            Boolean showDetailedErrorMessages)
        {
            ErrorService = errorService;
            ShowDetailedErrorMessages = showDetailedErrorMessages;

            // Errors come here before other error filters
            Order = 1;
        }

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

                // determine what sort of message we need to display to the user
                var errorMessage = GetErrorMessage(
                    exception, username,
                    ShowDetailedErrorMessages);

                // Create error view model
                var model = new ErrorViewModel
                {
                    PageTitle = PageTitles.Error,
                    PageSubTitle = PageSubTitles.ErroOccurredWhileProcessingAction,
                    ErrorMessage = errorMessage
                };

                // Fill that base view model with some data
                var controller = (BaseController)filterContext.Controller;
                controller.FillBaseViewModel(model);

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
        /// Gets the error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="username">The username.</param>
        /// <param name="ShowDetailedErrorMessages">if set to <c>true</c> [show detailed error messages].</param>
        /// <returns></returns>
        private static String GetErrorMessage(Exception exception,
            String username, Boolean ShowDetailedErrorMessages)
        {
            var friendlyMessageFormat = WarningText.FriendlyErrorMessageFormat;
            var detailedMessageText = (ShowDetailedErrorMessages ? exception.Message : String.Empty);
            var fullMessage = String.Format(friendlyMessageFormat, username, detailedMessageText);
            return fullMessage;
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
            catch (Exception) { }  // fail gracefully
        }
    }
}