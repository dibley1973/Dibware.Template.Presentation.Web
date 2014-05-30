using Dibware.Template.Presentation.Web.Exceptions;
using System;
using System.Text;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    /// <summary>
    /// Represents errors that occur due to invalid application model state.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class HandleModelStateExceptionForJsonAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// Called when an exception occurs and processes <see cref="ModelStateException"/> object.
        /// </summary>
        /// <param name="filterContext">Filter context.</param>
        public void OnException(ExceptionContext filterContext)
        {
            // Validate arguments
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // handle modelStateException
            if (filterContext.HttpContext.Request.IsAjaxRequest() // Removed for IE9 testing
                && (typeof(ModelStateException).IsInstanceOfType(filterContext.Exception))
                && !filterContext.ExceptionHandled)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.ContentEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.HeaderEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.StatusCode = 400;
                filterContext.Result = new JsonResult()
                {
                    Data = (filterContext.Exception as ModelStateException).ErrorForJsonResult
                };
            }
        }
    }
}