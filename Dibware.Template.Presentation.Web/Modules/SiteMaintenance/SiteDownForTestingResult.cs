using Dibware.Template.Presentation.Web.Resources;
using System.Net;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Modules.SiteMaintenance
{
    // Ref:
    //      ASP.NET MVC Maintenance pages and bringing your site back online.
    //      http://markeggers.net/post/mvc-maintenance-pages-and-bringing--site-back-online
    // 

    /// <summary>
    /// Encapsualtes the result of an action method for when teh site is down for testing
    /// </summary>
    public class SiteDownForTestingResult : ActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDownForTestingResult"/> class.
        /// </summary>
        public SiteDownForTestingResult() : base() { }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type 
        /// that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information 
        /// includes the controller, HTTP content, request context, and route data.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            // Get the path to the site down for testing page
            var path = HostingEnvironment.MapPath(StaticPages.SiteDownForTesting);

            // Get a local reference to the response object
            var response = context.HttpContext.Response;

            // Clear the current response and rewrite the status, output the 
            // site down page and end the response
            response.Clear();
            response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            response.StatusDescription = StatusDescriptionText.ServiceUnavailable;
            response.WriteFile(path);
            response.End();
        }
    }
}