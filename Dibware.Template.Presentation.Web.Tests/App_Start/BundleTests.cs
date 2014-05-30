using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dibware.Template.Presentation.Web.Tests.App_Start
{
    /// <summary>
    /// Test for BundlePaths
    /// Ref:
    ///   https://gist.github.com/carolynvs/3961521
    /// </summary>
    [TestClass]
    public class BundleTests
    {
        #region Private Members

        private BundleContext _mockBundleContext;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            var mockContext = (new Mock<HttpContextBase>(MockBehavior.Strict)).Object;
            _mockBundleContext = new BundleContext(mockContext, new BundleCollection(), String.Empty);

            BundleTable.EnableOptimizations = true;

            // Mock mapping a bundle item's virtual path to a physical path
            BundleTable.MapPathMethod = MapBundleItemPath;
        }

        ///// <summary>
        ///// Gets the bundle list.
        ///// </summary>
        ///// <param name="bundleCollection">The bundle collection.</param>
        ///// <returns></returns>
        //private static List<Bundle> GetBundleList(IEnumerable<Bundle> bundleCollection)
        //{
        //    return bundleCollection.ToList();
        //}

        /// <summary>
        /// Converts a bundle item's virtual path to a physical path
        /// </summary>
        /// <param name="item">The bundle item virtual path</param>
        /// <returns>The physical path of the bundl item</returns>
        private static String MapBundleItemPath(String item)
        {
            // Get project folder
            const String webProjectName = "dibware.template.presentation.web";
            var folderPath = ThisAssembly.GetProjectDirectory();
            folderPath = Directory.GetParent(folderPath).FullName;
            var pathToMvcProject = String.Concat(folderPath, @"\", webProjectName);

            // Strip the ~ and switch from / to \
            item = item.Replace("~", String.Empty).Replace("/", @"\");

            // Build final path
            var path = String.Format("{0}{1}", pathToMvcProject, item);
            return path;
        }

        #endregion

        #region Tests: Font Bundles

        [TestMethod]
        public void Test_FontBundles_ContainsBootstrap()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == BundlePaths.Fonts.Bootstrap);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(4, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Fonts.RegularEot));
            Assert.IsTrue(files.Contains(AssetPaths.Fonts.RegularSvg));
            Assert.IsTrue(files.Contains(AssetPaths.Fonts.RegularTtf));
            Assert.IsTrue(files.Contains(AssetPaths.Fonts.RegularWoff));
        }

        #endregion

        #region Tests: Style Bundles

        //[TestMethod]
        //public void Test_StyleBundles_ContainsBootstrap()
        //{
        //    // Arrange
        //    var bundles = new BundleCollection();

        //    // Act
        //    BundleConfig.RegisterBundles(bundles);
        //    var bundle = bundles.First(x => x.Path == BundlePaths.Styles.Bootstrap);
        //    var files = bundle.EnumerateFiles(_mockBundleContext)
        //        .Select(x => x.Name.ToLower())
        //        .OrderBy(x => x)
        //        .ToList();

        //    // Assert
        //    Assert.IsNotNull(bundle);
        //    Assert.AreEqual(2, files.Count);
        //    Assert.IsTrue(files.Contains(AssetPaths.Css.Layout.Bootstrap));
        //    Assert.IsTrue(files.Contains(AssetPaths.Css.Layout.BootstrapTheme));
        //}

        [TestMethod]
        public void Test_StyleBundles_ContainsMainLayout()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == BundlePaths.Styles.MainLayout);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(1, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Css.CommonLayout));
        }

        [TestMethod]
        public void Test_StyleBundles_ContainsBlackAndWhiteTheme()
        {
            // Arrange
            var bundles = new BundleCollection();
            const string bundlePath = BundlePaths.Styles.Themes.BlackAndWhite;

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == bundlePath);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(2, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Grey.Bootstrap));
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Grey.BootstrapTheme));
        }

        [TestMethod]
        public void Test_StyleBundles_ContainsGreyTheme()
        {
            // Arrange
            var bundles = new BundleCollection();
            const string bundlePath = BundlePaths.Styles.Themes.Grey;

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == bundlePath);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(2, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Grey.Bootstrap));
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Grey.BootstrapTheme));
        }

        [TestMethod]
        public void Test_StyleBundles_ContainsPinkTheme()
        {
            // Arrange
            var bundles = new BundleCollection();
            const string bundlePath = BundlePaths.Styles.Themes.Pink;

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == bundlePath);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(2, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Pink.Bootstrap));
            Assert.IsTrue(files.Contains(AssetPaths.Themes.Pink.BootstrapTheme));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_StyleBundles_ContainsInvalidTheme_ThrowsInvalidOperationException()
        {
            // Arrange
            var bundles = new BundleCollection();
            const string bundlePath = "Boop-de-doop";

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == bundlePath);

            // Assert
            Assert.IsNotNull(bundle);
            // Exception thrown
        }

        #endregion

        #region Tests: Script Bundles

        [TestMethod]
        public void Test_ScriptBundles_ContainsBootstrap()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == BundlePaths.Scripts.Bootstrap);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(1, files.Count);
            Assert.IsTrue(files.Contains(AssetPaths.Js.BootstrapMin));
        }

        [TestMethod]
        public void Test_ScriptBundles_ContainsJQuery()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            var bundle = bundles.First(x => x.Path == BundlePaths.Scripts.JQuery);
            var files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(1, files.Count);
        }

        [TestMethod]
        public void Test_ScriptBundles_ContainsJQueryUi()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            Bundle bundle = bundles.First(x => x.Path == BundlePaths.Scripts.JQueryUi);
            List<string> files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(1, files.Count);
            //Assert.IsTrue(files.Contains(Js.JQueryUi));
        }

        [TestMethod]
        public void Test_ScriptBundles_ContainsModernizr()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);
            Bundle bundle = bundles.First(x => x.Path == BundlePaths.Scripts.Modernizr);
            List<string> files = bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();

            // Assert
            Assert.IsNotNull(bundle);
            Assert.AreEqual(1, files.Count);
            //Assert.IsTrue(files.Contains(Js.Modernizr));
        }


        #endregion
    }
}