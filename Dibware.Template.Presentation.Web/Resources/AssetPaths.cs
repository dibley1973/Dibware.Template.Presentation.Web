using System;

namespace Dibware.Template.Presentation.Web.Resources
{
    public static class AssetPaths
    {
        public static class Prefixes
        {
            private const String AssetsPrefix = @"~/assets/";
            internal const String Css = AssetsPrefix + @"css/";
            internal const String Fonts = AssetsPrefix + @"fonts/";
            internal const String Js = AssetsPrefix + @"js/";
            internal const String Themes = AssetsPrefix + @"themes/";
        }

        public static class FileSuffixes
        {
            public const String BootstrapCss = @"bootstrap.css";
            public const String BootstrapThemeCss = @"bootstrap-theme.css";
        }

        public static class Css
        {
            public const String CommonLayout = Prefixes.Css + @"common-layout.css";
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

            public static class BlackAndWhite
            {
                public const String Name = "black-and-white";
                private const String BlackAndWhitePrefix = Prefixes.Css + ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = BlackAndWhitePrefix + FileSuffixes.BootstrapCss;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = BlackAndWhitePrefix + FileSuffixes.BootstrapThemeCss;
            }

            public static class Grey
            {
                public const String Name = "grey";
                private const String GreyPrefix = Prefixes.Css + ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = GreyPrefix + FileSuffixes.BootstrapCss;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = GreyPrefix + FileSuffixes.BootstrapThemeCss;
            }

            public static class Pink
            {
                public const String Name = "pink";
                private const String PinkPrefix = Prefixes.Css + ThemesPrefix + Name + @"/";
                public const String Bootstrap = FileSuffixes.BootstrapCss;
                public const String BootstrapPath = PinkPrefix + FileSuffixes.BootstrapCss;
                public const String BootstrapTheme = FileSuffixes.BootstrapThemeCss;
                public const String BootstrapThemePath = PinkPrefix + FileSuffixes.BootstrapThemeCss;
            }
        }
    }
}