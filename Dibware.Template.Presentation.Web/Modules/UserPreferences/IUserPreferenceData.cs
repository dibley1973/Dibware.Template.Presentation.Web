using System;

namespace Dibware.Template.Presentation.Web.Modules.UserPreferences
{
    /// <summary>
    /// Defines the expected members of an object that holds user preference data
    /// </summary>
    public interface IUserPreferenceData
    {
        /// <summary>
        /// Gets or sets the custom theme.
        /// </summary>
        /// <value>
        /// The custom theme.
        /// </value>
        String CustomTheme { get; set; }
    }
}