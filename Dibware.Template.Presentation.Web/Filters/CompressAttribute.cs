using System.IO.Compression;
using System.Web.Mvc;
using Dibware.Template.Presentation.Web.Resources;

namespace Dibware.Template.Presentation.Web.Filters
{
    public sealed class CompressAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Get request and response
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;

            // Get encoding possibilities of the request
            var acceptEncoding = request.Headers[RequestHeaders.AcceptEncoding];
            if (string.IsNullOrEmpty(acceptEncoding))
            {
                // No encoding accepted by the request... 
                // ...what crappy client is being used?!
                return;
            }

            // Check the response has a filter object instantiated
            if (response.Filter == null)
            {
                return;
            }

            // Check what coding is accepted and append the necessaries to the response
            if (acceptEncoding.ToUpperInvariant().Contains(CompressionEncoding.GZip.ToUpper()))
            {
                response.AppendHeader(ResponseHeaders.ContentEncoding, CompressionEncoding.GZip.ToLower());
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            }
            else if (acceptEncoding.ToUpperInvariant().Contains(CompressionEncoding.Deflate.ToUpper()))
            {
                response.AppendHeader(ResponseHeaders.ContentEncoding, CompressionEncoding.Deflate.ToLower());
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            }
        }
    }
}