using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Modules.UserPreferences;
using System.Security.Principal;

namespace Dibware.Template.Presentation.Web.Modules.Authentication
{
    /// <summary>
    /// Defines the expected members of a CliquePrinciple object
    /// </summary>
    public interface IWebsitePrincipal : IPrincipal
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user preferences.
        /// </summary>
        /// <value>
        /// The user preferences.
        /// </value>
        IUserPreferenceData UserPreferences { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        IApplicationConfiguration ApplicationConfiguration { get; set; }

        #endregion
    }
}