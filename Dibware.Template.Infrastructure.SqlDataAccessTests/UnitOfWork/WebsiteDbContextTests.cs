using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.UnitOfWork
{
    [TestClass]
    public class WebsiteDbContextTests
    {
        #region Declarations

        private WebsiteDbContext _unitOfWork;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Initialise unit of work
            _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();

            // Set db initialiser to create an empty database
            var initialiser = new WebsiteDbContextInitialiser();
            Database.SetInitializer(initialiser);
            initialiser.InitializeDatabase(_unitOfWork);
        }

        #endregion

        #region Tests

        #region ExecuteStoredProcedure

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CliqueDbContext_ExecuteStoredProcedureUsingNullProcedureName_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            _unitOfWork.ExecuteStoredProcedure(null, null);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CliqueDbContext_ExecuteStoredProcedureUsingEmptyProcedureName_ThrowsArgumentNullException()
        {
            // Arrange
            var procedureName = String.Empty;

            // Act
            _unitOfWork.ExecuteStoredProcedure(procedureName, null);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Test_CliqueDbContext_ExecuteStoredProcedureUsingIncorrectProcedureNameNullArgs_ThrowsSqlException()
        {
            // Arrange
            const string procedureName = "IncorrectProcName";

            // Act
            _unitOfWork.ExecuteStoredProcedure(procedureName, null);

            // Assert
            // Exception thrown
        }

        [Ignore] // Needs investigation how to set up
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Test_CliqueDbContext_ExecuteStoredProcedureUsingIncorrectProcedureNameWithArgs_ThrowsSqlException()
        {
            //// Arrange
            //const string procedureName = "IncorrectProcName";
            //object[] args =
            //{
            //    "buiscuit",
            //    7
            //};

            //// Act
            //_unitOfWork.ExecuteStoredProcedure(procedureName, args);

            //// Assert
            //// Exception thrown
        }

        #endregion

        #region ExecuteSqlQuery

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Test_CliqueDbContext_ExecuteSqlQueryUsingIncorrectSql_ThrowsSqlException()
        {
            // Arrange
            const string sql = "select moon from monkeys";

            // Act
            _unitOfWork.ExecuteSqlQuery<String>(sql);

            // Assert
            // Exception thrown
        }

        #endregion

        #endregion
    }
}
