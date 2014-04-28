using Dibware.Template.Presentation.Web.Filters;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Please note any filters that require dependency injection 
            // are bound in MvcApplication.RegisterGlobalFilters(), instead.
            // Currently:
            //      CustomHandleErrorAttribute

            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomHandleErrorAttribute()); //; See note above
            filters.Add(new HandleErrorForAjaxRequestAttribute());
            filters.Add(new ManageBaseViewModelAttribute());

            // filters.Add(new RemoveWhiteSpaceAttribute());
            // Removed this attribute as it seems to
            // duplicate some of the HTML!
        }
    }
}