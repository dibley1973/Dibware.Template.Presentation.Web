using System;
using System.Collections.Generic;
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