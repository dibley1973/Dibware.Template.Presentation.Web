using System;

namespace Dibware.Template.Presentation.Web.Resources
{
    public static class AssetPaths
    {
        public static class Prefixes
        {
            private const String AssetsPrefix = @"~/assets/";
            internal const String CssPrefix = AssetsPrefix + @"css/";
            internal const String FontsPrefix = AssetsPrefix + @"fonts/";
            internal const String JsPrefix = AssetsPrefix + @"js/";
            internal const String ThemesPrefix = AssetsPrefix + @"themes/";
        }

        private static class FileSuffixes
        {
            public const String BootstrapCss = @"bootstrap.css";
            public const String BootstrapThemeCss = @"bootstrap-theme.css";
        }

        public static class Css
        {
            public const String CommonLayout = @"common-layout.css";
            public const String CommonLayoutPath = Prefixes.CssPrefix + CommonLayout;
        }

        public static class Fonts
        {
            private const String RegularPrefix = @"glyphicons-halflings-regular.";

            public const String RegularEot = RegularPrefix + @"eot";
            public const String RegularEotPath = Prefixes.FontsPrefix + RegularEot;

            public const String RegularSvg = RegularPrefix + @"svg";
            public const String RegularSvgPath = Prefixes.FontsPrefix + RegularSvg;

            public const String RegularTtf = RegularPrefix + @"ttf";
            public const String RegularTtfPath = Prefixes.FontsPrefix + RegularTtf;

            public const String RegularWoff = RegularPrefix + @"woff";
            public const String RegularWoffPath = Prefixes.FontsPrefix + RegularWoff;
        }

        public static class Js
        {
            public const String BootstrapMin = @"bootstrap.js";
            public const String BootstrapMinPath = Prefixes.JsPrefix + BootstrapMin;
            public const String JQuery = @"jquery-{version}.js";
            public const String JQueryPath = Prefixes.JsPrefix + JQuery;
            public const String JQueryUi = @"jquery-ui-{version}.js";
            public const String JQueryUiPath = Prefixes.JsPrefix + JQueryUi;
            public const String Modernizr = @"modernizr-*";
            public const String ModernizrPath = Prefixes.JsPrefix + Modernizr;
        }

        public static class Themes
        {
            private const String ThemesPrefix = Prefixes.ThemesPrefix;

            public static class BlackAndWhite
            {
                public const String Name = "black-and-white";
                private const String BlackAndWhitePrefix = ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = BlackAndWhitePrefix + FileSuffixes.BootstrapCss;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = BlackAndWhitePrefix + FileSuffixes.BootstrapThemeCss;
            }

            public static class Grey
            {
                public const String Name = "grey";
                private const String GreyPrefix = ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = GreyPrefix + FileSuffixes.BootstrapCss;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = GreyPrefix + FileSuffixes.BootstrapThemeCss;
            }

            public static class Pink
            {
                public const String Name = "pink";
                private const String PinkPrefix = ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = PinkPrefix + Bootstrap;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = PinkPrefix + BootstrapTheme;
            }
        }
    }
}