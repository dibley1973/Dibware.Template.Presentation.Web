using System;
using System.Web;

namespace Dibware.Template.Presentation.Web.Helpers
{
    /// <summary>
    /// provides helper functions for IP addresses
    /// </summary>
    public static class IpAddressHelper
    {
        /// <summary>
        /// Gets the user host ip address.
        /// </summary>
        /// <param name="httpContextBase">The HTTP context base.</param>
        /// <returns></returns>
        internal static String GetUserHostIPAddress(HttpContextBase httpContextBase)
        {
            return httpContextBase.Request.UserHostAddress;
        }
    }
}