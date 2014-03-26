using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Configuration;

namespace Dibware.Template.Presentation.Web.Modules.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /// <summary>
        /// Gets the application environment.
        /// </summary>
        /// <value>
        /// The application environment.
        /// </value>
        public String ApplicationEnvironment
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationEnvironment]; }
        }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <value>
        /// The application title.
        /// </value>
        public String ApplicationTitle
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationTitle]; }
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        public String ApplicationVersion
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationVersion]; }
        }

        /// <summary>
        /// Gets or sets the name of the brand.
        /// </summary>
        /// <value>
        /// The name of the brand.
        /// </value>
        public String BrandName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.BrandName]; }
        }

        /// <summary>
        /// Gets the default theme name.
        /// </summary>
        /// <value>
        /// The default theme name.
        /// </value>
        /// <exception cref="NotImplementedException"></exception>
        public String DefaultThemeName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.DefaultThemeName]; }
        }

        #region role Names

        /// <summary>
        /// Gets the name of the administrator user role.
        /// </summary>
        /// <value>
        /// The name of the administrator user role.
        /// </value>
        public String AdministratorUserRoleName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.RoleName_AdministratorUser]; }
        }

        /// <summary>
        /// Gets the name of the main user role.
        /// </summary>
        /// <value>
        /// The name of the main user role.
        /// </value>
        public String MainUserRoleName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.RoleName_MainUser]; }
        }

        /// <summary>
        /// Gets the name of the super user role.
        /// </summary>
        /// <value>
        /// The name of the super user role.
        /// </value>
        /// <exception cref="NotImplementedException"></exception>
        public string SuperUserRoleName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.RoleName_SuperUser]; }
        }

        /// <summary>
        /// Gets the name of the unknown user role.
        /// </summary>
        /// <value>
        /// The name of the unknown user role.
        /// </value>
        public String UnknownUserRoleName
        {
            get { return ConfigurationManager.AppSettings[ConfigurationKeys.RoleName_UnknownUser]; }
        }

        #endregion
    }
}