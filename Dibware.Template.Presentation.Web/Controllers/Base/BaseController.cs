using Dibware.Template.Presentation.Web.Models.Base;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Resources;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers.Base
{
    /// <summary>
    /// This is the controller that holds all common implemntations
    /// and which all other controllers should inherit from.
    /// </summary>
    public class BaseController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the user security information for the current HTTP request.
        /// </summary>
        /// <returns>The user security information for the current HTTP request.</returns>
        protected virtual new IWebsitePrincipal User
        {
            get { return HttpContext.User as WebsitePrincipal; }
        }

        /// <summary>
        /// Gets or sets the application configuration.
        /// </summary>
        /// <value>
        /// The application configuration.
        /// </value>
        [Inject]
        public IApplicationConfiguration ApplicationConfiguration { get; set; }

        #endregion

        /// <summary>
        /// Fills the base view model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void FillBaseViewModel(BaseViewModel model)
        {
            // Set the page metatag data
            SetModelCommonMetaTagData(model);

            var user = (WebsitePrincipal)User;
            var appConfiguration = user.ApplicationConfiguration;
            model.BrandName = appConfiguration.BrandName;

            if (!model.HasCustomColourTheme)
            {
                model.CustomColourTheme = AssetPaths.Themes.Grey.Name; //TODO: get from web config via app config.
            }

            // Fill Font Bundle paths
            FillListWithFontBundlePaths(model.FontBundlePathList);

            // Fill JavaScript Bundle paths
            FillListWithJavaScriptBundlePaths(model.JavaScriptBundlePathList);

            // Fill Stylesheet bundle paths
            FillListWithStylesheetBundlePaths(model.StylesheetBundlePathList);

            // Fill colour theme Stylesheet bundle paths
            if (model.HasCustomColourTheme)
            {
                FillListWithColourThemeStylesheetBundlePaths(model.StylesheetBundlePathList, model.CustomColourTheme);
            }
        }

        /// <summary>
        /// Fills the list with JavaScript bundle paths.
        /// </summary>
        /// <param name="fontBundlePathList">The font bundle path list.</param>
        private static void FillListWithFontBundlePaths(ICollection<String> fontBundlePathList)
        {
            fontBundlePathList.Add(BundlePaths.Fonts.Bootstrap);
        }

        /// <summary>
        /// Fills the list with JavaScript bundle paths.
        /// </summary>
        /// <param name="javaScriptBundlePathList">The java script bundle path list.</param>
        private static void FillListWithJavaScriptBundlePaths(ICollection<String> javaScriptBundlePathList)
        {
            javaScriptBundlePathList.Add(BundlePaths.Scripts.JQuery);
            javaScriptBundlePathList.Add(BundlePaths.Scripts.JQueryUi);
            javaScriptBundlePathList.Add(BundlePaths.Scripts.Bootstrap);
            javaScriptBundlePathList.Add(BundlePaths.Scripts.Modernizr);
        }

        /// <summary>
        /// Fills the list with stylesheet bundle paths.
        /// </summary>
        /// <param name="stylesheetBundlePathList">The stylesheet bundle path list to fill.</param>
        private static void FillListWithStylesheetBundlePaths(ICollection<String> stylesheetBundlePathList)
        {
            stylesheetBundlePathList.Add(BundlePaths.Styles.MainLayout);
        }

        /// <summary>
        /// Fills the list with colour theme stylesheet bundle paths.
        /// </summary>
        /// <param name="stylesheetBundlePathList">The stylesheet bundle path list.</param>
        /// <param name="themeColour">The theme colour.</param>
        private static void FillListWithColourThemeStylesheetBundlePaths(ICollection<String> stylesheetBundlePathList, String themeColour)
        {
            // Look for recognised colour theme names 
            // and add the respective colour theme bundle
            switch (themeColour)
            {
                case AssetPaths.Themes.BlackAndWhite.Name:
                    stylesheetBundlePathList.Add(BundlePaths.Styles.Themes.BlackAndWhite);
                    break;

                case AssetPaths.Themes.Grey.Name:
                    stylesheetBundlePathList.Add(BundlePaths.Styles.Themes.Grey);
                    break;

                case AssetPaths.Themes.Pink.Name:
                    stylesheetBundlePathList.Add(BundlePaths.Styles.Themes.Pink);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(ExceptionMessages.UnexpectedCustomThemeNameEncountered);
            }
        }

        /// <summary>
        /// Sets the common meta tag data.
        /// </summary>
        /// <param name="model">The model.</param>
        private static void SetModelCommonMetaTagData(BaseViewModel model)
        {
            model.MetaAuthor = MetaTagData.Author;
            model.MetaDescription = MetaTagData.Description;
        }
    }
}