using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Modules.SiteMaintenance
{
    /// <summary>
    /// Checks for the presence of a file and set sthe filterContext result to 
    /// be of type SiteDownForTestingResult.
    /// </summary>
    public sealed class BlockSiteAccessOnTestingAttribute : ActionFilterAttribute
    {
        #region Private Members

        private const Int32 CacheTimeInMinutes = 1;
        private const Boolean SlidingExpiration = false;
        private static readonly String CacheItemKey = CacheKeys.IsTestingState;

        #endregion

        #region Methods

        /// <summary>
        /// Called when the action is executing.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Determine if we are testing
            var isTesting = GetIsTestingState();
            if (isTesting)
            {
                // ... we are, so now we now need to find if the user has a valid 
                // testing IP address as we only want to allow valid ip addresses 
                // through.
                var hasUserValidTestingIpAddress = GetHasUserValidTestingIpAddress(filterContext.HttpContext);
                if (!hasUserValidTestingIpAddress)
                {
                    // requests from other IP addresses get kicked back
                    filterContext.Result = new SiteDownForTestingResult();
                }
            }

            // Cach the state for next request
            CacheTheIsTestingFlag(isTesting);

            // Pass on through to the base class
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Gets a value indicating if the has user valid testing IP address.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        private static Boolean GetHasUserValidTestingIpAddress(HttpContextBase httpContext)
        {
            var validIPAddresses = GetValidTestingIPAddresses(httpContext);
            var currentIPAddress = IpAddressHelper.GetUserHostIPAddress(httpContext);
            return validIPAddresses.Contains(currentIPAddress);
        }

        /// <summary>
        /// Gets the state of the is testing.
        /// </summary>
        /// <returns></returns>
        private static Boolean GetIsTestingState()
        {
            Boolean isTesting;

            // See if we already have a cached value...
            Boolean? cachedIsTesting = GetCachedStateOfIsTestingFlag();
            if (cachedIsTesting.HasValue)
            {
                // ... if so use the cached value
                isTesting = cachedIsTesting.Value;
            }
            else
            {
                // ... we dont so check if the file exists which will indicate 
                // we are testing...
                var path = HostingEnvironment.MapPath(StaticPages.SiteDownForTesting);
                isTesting = File.Exists(path);
            }

            // retur the result
            return isTesting;
        }

        /// <summary>
        /// Gets the cached state of "Is Testing" flag.
        /// </summary>
        /// <returns></returns>
        private static bool? GetCachedStateOfIsTestingFlag()
        {
            return WebCache.Get(CacheItemKey);
        }

        /// <summary>
        /// Gets the valid testing ip addresses.
        /// </summary>
        /// <param name="httpContextBase">The HTTP context base.</param>
        /// <returns></returns>
        private static List<String> GetValidTestingIPAddresses(HttpContextBase httpContextBase)
        {
            //TODO get list from database
            return new List<String>();
        }

        /// <summary>
        /// Caches the state of the "Is Testing" flag.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private static void CacheTheIsTestingFlag(Boolean state)
        {
            WebCache.Set(CacheItemKey, state, CacheTimeInMinutes, SlidingExpiration);
        }

        #endregion
    }
}