using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using System.Data.Entity;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Repositories
{
    [TestClass]
    public class StatusRepositoryTest
    {
        #region Private Members

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

        #region IStatusRepository

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_StatusRepository_GetAllWithNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            var repository = (IStatusRepository)new StatusRepository(null);

            // Act
            var actualResult = repository.GetAll();

            // Assert
            // Exception Thrown
        }

        [TestMethod]
        public void Test_StatusRepository_GetDefault_ReturnsDefaultState()
        {
            // Arrange
            var repository = (IStatusRepository)new StatusRepository(_unitOfWork);
            var defaultId = StatusData.DefaultStatus.Id;
            var expectedState = StatusData.DefaultStatus.State;

            // Act
            var actualResult = repository.GetForId(defaultId);

            // Assert
            Assert.AreEqual(expectedState, actualResult.State);
        }

        #endregion

        #endregion
    }
}
