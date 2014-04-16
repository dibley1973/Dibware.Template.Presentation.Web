using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Repositories
{
    [TestClass]
    public class ErrorRepositoryTests
    {
        #region Declarations

        private WebsiteDbContext _unitOfWork;

        #endregion Declarations

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

        #endregion Test Initialise

        #region Tests

        #region IErrorRepository

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ErrorRepository_GetAllWithNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            var repository = (IErrorRepository)new ErrorRepository(null);

            // Act
            var actualResult = repository.GetAll();

            // Assert
            // Exception Thrown
        }


        #endregion

        #endregion
    }
}