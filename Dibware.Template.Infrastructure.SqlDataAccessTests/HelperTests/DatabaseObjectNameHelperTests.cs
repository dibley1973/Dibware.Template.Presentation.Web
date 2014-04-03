using System;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.HelperTests
{
    [TestClass]
    public class DatabaseObjectNameHelperTests
    {
        #region Fields

        private const String SchemaName = "app";
        private const String TableName = "MyTable";
        private const String SprocAction = "Update";

        #endregion

        #region Tests

        [TestMethod]
        public void Test_DatabaseObjectNameHelper_GetFullTableName_ReturnsCorrectFormat()
        {
            // Arrange
            var expected = String.Concat(SchemaName, ".", TableName);

            // Act
            var actual = DatabaseObjectNameHelper.GetFullTableName(SchemaName, TableName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DatabaseObjectNameHelper_GetFullStoredProcedureName_ReturnsCorrectFormat()
        {
            // Arrange
            var expected = String.Concat(SchemaName, ".", TableName, "_", SprocAction);

            // Act
            var actual = DatabaseObjectNameHelper.GetFullStoredProcedureName(SchemaName, TableName, SprocAction);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        #endregion
    }
}