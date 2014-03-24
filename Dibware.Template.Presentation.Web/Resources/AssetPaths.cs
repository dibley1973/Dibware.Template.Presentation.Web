using System;

namespace Dibware.Template.Presentation.Web.Resources
{
    public static class AssetPaths
    {
        public static class Prefixes
        {
            private const String AssetsPrefix = @"~/assets/";
            public const String Css = AssetsPrefix + @"css/";
            public const String Fonts = AssetsPrefix + @"fonts/";
            public const String Js = AssetsPrefix + @"js/";
            public const String Themes = AssetsPrefix + @"themes/";
        }

        public static class Fonts
        {
            private const String RegularPrefix = @"glyphicons-halflings-regular.";

            public const String RegularEot = RegularPrefix + @"eot";
            public const String RegularEotPath = Prefixes.Fonts + RegularEot;

            public const String RegularSvg = RegularPrefix + @"svg";
            public const String RegularSvgPath = Prefixes.Fonts + RegularSvg;

            public const String RegularTtf = RegularPrefix + @"ttf";
            public const String RegularTtfPath = Prefixes.Fonts + RegularTtf;

            public const String RegularWoff = RegularPrefix + @"woff";
            public const String RegularWoffPath = Prefixes.Fonts + RegularWoff;
        }

        public static class Js
        {
            public const String BootstrapMin = @"bootstrap.js";
            public const String BootstrapMinPath = Prefixes.Js + BootstrapMin;
            public const String JQuery = @"jquery-{version}.js";
            public const String JQueryPath = Prefixes.Js + JQuery;
            public const String JQueryUi = @"jquery-ui-{version}.js";
            public const String JQueryUiPath = Prefixes.Js + JQueryUi;
            public const String Modernizr = @"modernizr-*";
            public const String ModernizrPath = Prefixes.Js + Modernizr;
        }

        public static class Themes
        {
            private const String ThemesPrefix = @"themes/";

            public static class Grey
            {
                public const String Name = "grey";
                private const String GreyPrefix = Prefixes.Css + ThemesPrefix + @"grey/";
                public const String Bootstrap = @"bootstrap.css";
                public const String BootstrapPath = GreyPrefix + Bootstrap;
                public const String BootstrapTheme = @"bootstrap-theme.css";
                public const String BootstrapThemePath = GreyPrefix + BootstrapTheme;
            }
        }
    }
}