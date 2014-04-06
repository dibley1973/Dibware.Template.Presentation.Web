using System;

namespace Dibware.Template.Presentation.Web.Models.Navigation
{
    /// <summary>
    /// Represents a navigation item, used for menus and such.
    /// </summary>
    public class NavigationItem
    {
        public String Description { get; set; }
        public String Title { get; set; }
        public String Url { get; set; }
    }
}