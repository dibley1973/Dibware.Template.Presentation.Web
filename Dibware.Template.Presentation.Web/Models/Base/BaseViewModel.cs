using Dibware.Extensions.System;
using Dibware.Template.Core.Domain.Entities.Application;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Presentation.Web.Models.Base
{
    /// <summary>
    /// This is view model that all other view models should
    /// inherit from and contains all base implementation.
    /// </summary>
    public class BaseViewModel
    {
        #region Constructors and initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        public BaseViewModel()
        {
            InitializeBundleLists();
            InitializeNotificationList();
        }

        /// <summary>
        /// Initializes the bundle lists.
        /// </summary>
        private void InitializeBundleLists()
        {
            FontBundlePathList = new List<String>();
            JavaScriptBundlePathList = new List<String>();
            StylesheetBundlePathList = new List<String>();
        }

        /// <summary>
        /// Initializes the Notification list.
        /// </summary>
        private void InitializeNotificationList()
        {
            Notifications = new List<Notification>();
        }

        #endregion Constructors and initializers

        #region Properties

        #region Branding

        public String BrandName { get; set; }

        /// <summary>
        /// Returns a value indicating if a Brand Name has been set.
        /// </summary>
        /// <returns><c>true</c> if a BrandName has been set.</returns>
        public Boolean HasBrandName
        {
            get { return BrandName.HasValue(); }
        }

        #endregion

        #region Meta Tags

        /// <summary>
        /// Gets or sets the meta author.
        /// </summary>
        /// <value>
        /// The meta author.
        /// </value>
        public String MetaAuthor { get; set; }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        /// <value>
        /// The meta description.
        /// </value>
        public String MetaDescription { get; set; }

        #endregion Meta Tags

        #region Site Map

        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        /// <value>
        /// The page title.
        /// </value>
        public String PageTitle { get; set; }

        /// <summary>
        /// Gets or sets the page sub title.
        /// </summary>
        /// <value>
        /// The page sub title.
        /// </value>
        public String PageSubTitle { get; set; }

        #endregion Site Map

        #region Colour Theme

        /// <summary>
        /// Gets or sets the custom colour theme
        /// </summary>
        public String CustomColourTheme { get; set; }

        /// <summary>
        /// Returns a value indicating if a custom colour theme has been set.
        /// </summary>
        /// <returns><c>true</c> if a custom colour theme has been set.</returns>
        public Boolean HasCustomColourTheme
        {
            get { return CustomColourTheme.HasValue(); }
        }

        #endregion

        #region BundleLists

        /// <summary>
        /// Gets or sets the font bundle path list.
        /// </summary>
        /// <value>
        /// The Font bundle path list.
        /// </value>
        public List<String> FontBundlePathList { get; private set; }

        /// <summary>
        /// Gets or sets the JavaScript bundle path list.
        /// </summary>
        /// <value>
        /// The JavaScript bundle path list.
        /// </value>
        public List<String> JavaScriptBundlePathList { get; private set; }

        /// <summary>
        /// Gets or sets the Stylesheet bundle path list.
        /// </summary>
        /// <value>
        /// The stylesheet bundle path list.
        /// </value>
        public List<String> StylesheetBundlePathList { get; private set; }

        #endregion

        #region User Details

        #endregion

        #region Notifcations

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public List<Notification> Notifications { get; set; }

        #endregion

        #endregion Properties
    }
}