using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Navigation;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class NavigationController : BaseController
    {
        #region Actions

        /// <summary>
        /// Returs a partial View for the header navigation
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HeaderNavigation()
        {
            // Create model
            HeaderNavigationViewModel model = new HeaderNavigationViewModel();

            // Create Nav Items
            List<NavigationItem> navigationItems = new List<NavigationItem>();

            // Get current node
            SiteMapNode rootNode = SiteMap.RootNode;

            // Get all children of the root node and add them
            // into the navigation items collection
            foreach (SiteMapNode childNode in rootNode.ChildNodes)
            {
                // Create a navigation item from the child node
                var item = new NavigationItem()
                {
                    Description = childNode.Description,
                    Title = childNode.Title,
                    Url = Url.Content(childNode.Url)
                };

                // Add to list
                navigationItems.Add(item);
            }

            // Set nav items to model
            model.NavigationItems = navigationItems;

            return PartialView(model);
        }

        #endregion
    }
}