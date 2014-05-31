using System;

namespace Dibware.Template.Presentation.Web.Resources
{
    /// <summary>
    /// Encapsulates bundle paths
    /// </summary>
    public static class BundlePaths
    {
        public static class Fonts
        {
            public const String Bootstrap = @"~/bundles/bootstrap/fonts";
        }

        public static class Scripts
        {
            public const String Bootstrap = @"~/bundles/bootstrap/js";
            public const String JQuery = @"~/bundles/jquery";
            public const String JQueryUi = @"~/bundles/jqueryui";
            public const String JQueryUnobtrusive = @"~/bundles/jqueryunobtrusive";
            public const String JQueryVal = @"~/bundles/jqueryval";
            public const String Modernizr = @"~/bundles/modernizr";
            public const String Bootbar = @"~/bundles/bootbar";
        }

        public static class Styles
        {
            //public const String Bootstrap = @"~/Bootstrap/css";
            //public const String Common = @"~/styles/common";
            public const String MainLayout = @"~/MainLayout/css";

            public static class Themes
            {
                public const String BlackAndWhite = @"~/BlackAndWhiteTheme/css";
                public const String Grey = @"~/GreyTheme/css";
                public const String Pink = @"~/PinkTheme/css";
            }
        }
    }
}