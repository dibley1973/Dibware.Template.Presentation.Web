using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

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

        #region ApplyCurrentValues

        [TestMethod]
        public void Test_WebsiteDbContext_ApplyCurrentValuesChangingNameProperty_ResultsInNamePropertyChanged()
        {
            // Arrange
            var existingEntity = _unitOfWork.CreateSet<Role>().First();
            var currentEntity = new Role
            {
                Key = existingEntity.Key,
                Name = "New Name"
            };

            // Act
            _unitOfWork.ApplyCurrentValues(existingEntity, currentEntity);

            // Assert
            Assert.AreEqual(existingEntity.Key, currentEntity.Key);
            Assert.AreEqual(existingEntity.Name, currentEntity.Name);
        }


        #endregion

        #region ExecuteStoredProcedure

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebsiteDbContext_ExecuteStoredProcedureUsingNullProcedureName_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            _unitOfWork.ExecuteStoredProcedure(null, null);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebsiteDbContext_ExecuteStoredProcedureUsingEmptyProcedureName_ThrowsArgumentNullException()
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
        public void Test_WebsiteDbContext_ExecuteStoredProcedureUsingIncorrectProcedureNameNullArgs_ThrowsSqlException()
        {
            // Arrange
            const string procedureName = "IncorrectProcName";

            // Act
            _unitOfWork.ExecuteStoredProcedure(procedureName, null);

            // Assert
            // Exception thrown
        }

        //[Ignore] // Needs investigation how to set up
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_WebsiteDbContext_ExecuteStoredProcedureUsingIncorrectProcedureNameWithArgs_ThrowsArgumentException()
        {
            // Arrange
            const string procedureName = "IncorrectProcName";
            object[] args =
            {
                "buiscuit",
                7
            };

            // Act
            _unitOfWork.ExecuteStoredProcedure(procedureName, args);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        public void Test_WebsiteDbContext_ExecuteStoredProcedureUsingValidProcedureNameWithArgs_DoesNotException()
        {
            // Arrange
            const string procedureName = "security.Role_Insert";
            var role = new Role
            {
                Key = "key",
                Name = "New Role Name"
            };

            // Act
            _unitOfWork.ExecuteStoredProcedure(procedureName, role);

            // Assert
            // No Exception thrown
        }

        #endregion

        #region ExecuteSqlQuery

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Test_WebsiteDbContext_ExecuteSqlQueryUsingIncorrectSql_ThrowsSqlException()
        {
            // Arrange
            const string sql = "select moon from monkeys";

            // Act
            _unitOfWork.ExecuteSqlQuery<String>(sql);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        public void Test_WebsiteDbContext_ExecuteSqlQueryUsingValidSql_DoesNotThrowException()
        {
            // Arrange
            const Int32 expectedCount = 1;
            const string sql = "SELECT Top 1 Name FROM security.Role";

            // Act
            var result = _unitOfWork.ExecuteSqlQuery<String>(sql);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        #endregion

        #endregion
    }
}
