using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Modules.UserPreferences;
using Dibware.Web.Security.Principal;
using Ninject;

namespace Dibware.Template.Presentation.Web.Modules.Authentication
{
    public class WebsitePrincipal : WebPrincipal, IPrincipal, IWebsitePrincipal
    {
        #region IWebsitePrincipal members

        /// <summary>
        /// Gets or sets the user preferences.
        /// </summary>
        /// <value>
        /// The user preferences.
        /// </value>
        [Inject]
        public IUserPreferenceData UserPreferences { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [Inject]
        public IApplicationConfiguration ApplicationConfiguration { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is an administrator user.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is an administrator user; otherwise, <c>false</c>.
        /// </value>
        public bool IsAdministratorUser
        {
            get { return IsInRole(ApplicationConfiguration.AdministratorUserRoleName); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is a main user.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is a main user; otherwise, <c>false</c>.
        /// </value>
        public bool IsMainUser
        {
            get { return IsInRole(ApplicationConfiguration.MainUserRoleName); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is an unknowh user.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is an unknown user; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnknownUser
        {
            get { return IsInRole(ApplicationConfiguration.UnknownUserRoleName); }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name
        {
            get
            {
                var ti = new CultureInfo("en-US", false).TextInfo;
                return ti.ToTitleCase(Identity.Name);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsitePrincipal" /> class.
        /// </summary>
        /// <param name="identity">The windows identity.</param>
        public WebsitePrincipal(WebIdentity identity)
            : base(identity) { }

        #endregion
    }
}