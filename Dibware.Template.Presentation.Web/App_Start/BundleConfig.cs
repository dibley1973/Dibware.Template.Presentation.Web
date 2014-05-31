using System.Web.Optimization;
using Dibware.Template.Presentation.Web.Resources;

namespace Dibware.Template.Presentation.Web
{
    public static class BundleConfig
    {
        // For more information on Bundling, visit
        //      http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JavaScript

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQuery).Include(
                AssetPaths.Js.JQueryPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQueryUi).Include(
                AssetPaths.Js.JQueryUiPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQueryUnobtrusive).Include(
                AssetPaths.Js.JQueryUnobtrusivePath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQueryVal).Include(
                AssetPaths.Js.JQueryValPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.Bootstrap).Include(
                AssetPaths.Js.BootstrapMinPath
            ));

            // Use the development version of Modernizr to develop with and
            // learn from. Then, when you're ready for production, use the build
            // tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(BundlePaths.Scripts.Modernizr).Include(
                AssetPaths.Js.ModernizrPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.Bootbar).Include(
                AssetPaths.Js.BootbarMinPath
            ));

            #endregion

            #region Fonts

            bundles.Add(new Bundle(BundlePaths.Fonts.Bootstrap).Include(
                AssetPaths.Fonts.RegularEotPath,
                AssetPaths.Fonts.RegularTtfPath,
                AssetPaths.Fonts.RegularSvgPath,
                AssetPaths.Fonts.RegularWoffPath
            ));

            #endregion

            #region StyleSheets

            // Common layout
            bundles.Add(new StyleBundle(BundlePaths.Styles.MainLayout).Include(
                AssetPaths.Css.CommonLayoutPath
            ));

            // Black and White Theme
            bundles.Add(new StyleBundle(BundlePaths.Styles.Themes.BlackAndWhite).Include(
                AssetPaths.Themes.BlackAndWhite.BootstrapPath,
                AssetPaths.Themes.BlackAndWhite.BootstrapThemePath
            ));

            // Grey Theme
            bundles.Add(new StyleBundle(BundlePaths.Styles.Themes.Grey).Include(
                AssetPaths.Themes.Grey.BootstrapPath,
                AssetPaths.Themes.Grey.BootstrapThemePath
            ));
            
            // Pink Theme
            bundles.Add(new StyleBundle(BundlePaths.Styles.Themes.Pink).Include(
                AssetPaths.Themes.Pink.BootstrapPath,
                AssetPaths.Themes.Pink.BootstrapThemePath
            ));

            #endregion
        }
    }
}