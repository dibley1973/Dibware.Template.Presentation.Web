using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CompressAttribute());
            //filters.Add(new HandleErrorForAjaxRequestAttribute());
            //filters.Add(new CustomHandleErrorAttribute());
            //filters.Add(new ManageBaseViewModelAttribute());

            // Removed this attribute as it seems to
            // duplicate some of the HTML!
            //filters.Add(new RemoveWhiteSpaceAttribute());
        }
    }
}