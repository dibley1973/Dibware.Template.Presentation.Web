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
            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQuery).Include(
                Resources.AssetPaths.Js.JQueryPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.JQueryUi).Include(
                Resources.AssetPaths.Js.JQueryUiPath
            ));

            bundles.Add(new ScriptBundle(BundlePaths.Scripts.Bootstrap).Include(
                Resources.AssetPaths.Js.BootstrapMinPath
            ));

            // Use the development version of Modernizr to develop with and
            // learn from. Then, when you're ready for production, use the build
            // tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(BundlePaths.Scripts.Modernizr).Include(
                Resources.AssetPaths.Js.ModernizrPath
            ));
        }

    }
}