using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Modules.UserPreferences;
using System;
using System.Security.Principal;

namespace Dibware.Template.Presentation.Web.Modules.Authentication
{
    /// <summary>
    /// Defines the expected members of a WebsitePrinciple object
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

        /// <summary>
        /// Gets a value indicating whether this instance is an administrator user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is an administrator user; otherwise, <c>false</c>.
        /// </value>
        Boolean IsAdministratorUser { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is a main user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is a main user; otherwise, <c>false</c>.
        /// </value>
        Boolean IsMainUser { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is an unknowh user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is an unknown user; otherwise, <c>false</c>.
        /// </value>
        Boolean IsUnknownUser { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        String Name { get; }

        #endregion
    }
}