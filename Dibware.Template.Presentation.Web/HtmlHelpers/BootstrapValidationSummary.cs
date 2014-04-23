using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Dibware.Template.Presentation.Web.HtmlHelpers
{
    /// <summary>
    /// HTML Helper for Bootrap style validation summary.
    /// Based upon helper by "oexenhave"
    /// 
    /// Ref:
    ///     http://stackoverflow.com/questions/13867307/show-validationsummary-mvc33-as-alert-error-bootstrap
    /// </summary>
    public static class BootstrapValidationSummaryExtensions
    {
        /// <summary>
        /// Returns an unordered list (ul element) of validation messages that are in
        //  the System.Web.Mvc.ModelStateDictionary object in a Bootsrap formatted div
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <returns>
        /// A string that contains an unordered list (ul element) of validation 
        /// messages formatted in a bootstrap error.
        /// </returns>
        public static HtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper)
        {
            // Validate parameters
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }

            // Return Empty string if there are no validation errors
            if (htmlHelper.ViewData.ModelState.IsValid)
            {
                return new HtmlString(String.Empty);
            }

            // Return bootstrap formatted list of validation errors
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<div class=\"alert alert-danger\">");
            htmlBuilder.AppendLine("<button type='button' class='close' data-dismiss='alert'>&times;</button>");
            htmlBuilder.AppendLine("<h4>Warning!</h4>");
            htmlBuilder.AppendLine(htmlHelper.ValidationSummary().ToString());
            htmlBuilder.AppendLine("</div>");
            return new HtmlString(htmlBuilder.ToString());
        }
    }
}