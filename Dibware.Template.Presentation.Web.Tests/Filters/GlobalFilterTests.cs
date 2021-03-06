﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Tests.Filters
{
    [TestClass]
    public class GlobalFilterTests
    {
        #region Private Members

        private GlobalFilterCollection _filters;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            _filters = new GlobalFilterCollection();
        }

        #endregion

        #region Tests: Filters

        [TestMethod]
        public void Test_GlobalFilters_CheckCount_ReturnsFive()
        {
            // Arrange

            // Act
            FilterConfig.RegisterGlobalFilters(_filters);

            // Assert
            Assert.AreEqual(2, _filters.Count);
        }

        [TestMethod]
        public void Test_GlobalFilters_ContainsHandleErrorAttribute()
        {
            // Arrange
            const String filterFullName = "System.Web.Mvc.HandleErrorAttribute";

            // Act
            FilterConfig.RegisterGlobalFilters(_filters);
            var filter = _filters.First(f => f.Instance.GetType().FullName == filterFullName);

            // Assert
            Assert.IsNotNull(filter);
        }

        [TestMethod]
        public void Test_GlobalFilters_ContainsManageBaseViewModelAttribute()
        {
            // Arrange
            const String filterFullName = "Dibware.Template.Presentation.Web.Filters.ManageBaseViewModelAttribute";

            // Act
            FilterConfig.RegisterGlobalFilters(_filters);
            var filter = _filters.First(f => f.Instance.GetType().FullName == filterFullName);

            // Assert
            Assert.IsNotNull(filter);
        }

        [TestMethod]
        public void Test_GlobalFilters_ContainsHandleErrorForAjaxRequestAttribute()
        {
            // Arrange
            const String filterFullName = "Dibware.Template.Presentation.Web.Filters.HandleErrorForAjaxRequestAttribute";

            // Act
            FilterConfig.RegisterGlobalFilters(_filters);
            var filter = _filters.First(f => f.Instance.GetType().FullName == filterFullName);

            // Assert
            Assert.IsNotNull(filter);
        }

        [Ignore]    // As the CustomErrorHandler attribute requires DI so is not registered in "RegisterGlobalFilters"
        [TestMethod]
        public void Test_GlobalFilters_ContainsCustomHandleErrorAttribute()
        {
            // Arrange
            const String filterFullName = "Dibware.Template.Presentation.Web.Filters.CustomHandleErrorAttribute";

            // Act
            FilterConfig.RegisterGlobalFilters(_filters);
            var filter = _filters.First(f => f.Instance.GetType().FullName == filterFullName);

            // Assert
            Assert.IsNotNull(filter);
        }

        #endregion
    }
}