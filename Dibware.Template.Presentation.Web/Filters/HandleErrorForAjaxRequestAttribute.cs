using System.Text;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    public sealed class HandleErrorForAjaxRequestAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // If normal request go down normal channels to raise exception
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest()
                && !filterContext.ExceptionHandled)
            {
                // Request is ajax request, just throw the message as a content result
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.ContentEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.HeaderEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new ContentResult
                {
                    Content = filterContext.Exception.Message,
                    ContentEncoding = Encoding.UTF8
                };
            }
        }
    }
}