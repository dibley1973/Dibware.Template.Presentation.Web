using System;
using System.Collections.Generic;

namespace Dibware.Template.Presentation.Web.Modules.ApplicationState
{
    public static class ApplicationStatus
    {

        //private static ApplicationStatusProvider _defaultProvider;
        private static Dictionary<String, ApplicationStatusProvider> _providers;

        static ApplicationStatus()
        {
            _providers = new Dictionary<String, ApplicationStatusProvider>();
        }

        public static String DefaultProvider { get; set; }

        //
        // Summary:
        //     Gets a reference to the default application status provider for the application.
        //
        // Returns:
        //     The default membership provider for the application exposed using the System.Web.Security.MembershipProvider
        //     abstract base class.
        public static ApplicationStatusProvider Provider
        {
            get
            {
                return _providers[DefaultProvider];
            }
        }

        /// <summary>
        /// Gets a Dictionary of all application status providers for the application.
        /// </summary>
        /// <value>
        /// The providers.
        /// </value>
        public static Dictionary<String, ApplicationStatusProvider> Providers { get { return _providers; } }
    }
}