using System;

namespace Dibware.Template.Presentation.Web.Helpers
{
    public static class LinkHelper
    {
        public static String CreateLink(String domain, String relativeUrl)
        {
            var link = String.Concat(domain, "/", relativeUrl);
            // TODO: may need to do further cleaning here..
            // maybe remove a "tilde"?
            return link;
        }
    }
}