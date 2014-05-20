using System;

namespace Dibware.Template.Presentation.Web.Modules.Configuration
{
    /// <summary>
    /// Defines the expected members for application config settings
    /// </summary>
    public interface IApplicationConfiguration
    {
        /// <summary>
        /// Gets the application environment.
        /// </summary>
        /// <value>
        /// The application environment.
        /// </value>
        String ApplicationEnvironment { get; }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <value>
        /// The application title.
        /// </value>
        String ApplicationTitle { get; }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        String ApplicationVersion { get; }

        /// <summary>
        /// Gets the name of the brand.
        /// </summary>
        /// <value>
        /// The name of the brand.
        /// </value>
        String BrandName { get; }

        /// <summary>
        /// Gets the ID of the default application status.
        /// </summary>
        /// <value>
        /// The id of the default application status.
        /// </value>
        Int32 DefaultApplicationStatusId { get; }

        /// <summary>
        /// Gets the default theme name.
        /// </summary>
        /// <value>
        /// The default theme name.
        /// </value>
        String DefaultThemeName { get; }

        #region role Names

        /// <summary>
        /// Gets the name of the administrator user role.
        /// </summary>
        /// <value>
        /// The name of the administrator user role.
        /// </value>
        String AdministratorUserRoleName { get; }

        /// <summary>
        /// Gets the name of the main user role.
        /// </summary>
        /// <value>
        /// The name of the main user role.
        /// </value>
        String MainUserRoleName { get; }

        /// <summary>
        /// Gets the name of the super user role.
        /// </summary>
        /// <value>
        /// The name of the super user role.
        /// </value>
        String SuperUserRoleName { get; }

        /// <summary>
        /// Gets the name of the unknown user role.
        /// </summary>
        /// <value>
        /// The name of the unknown user role.
        /// </value>
        String UnknownUserRoleName { get; }

        #endregion
    }
}