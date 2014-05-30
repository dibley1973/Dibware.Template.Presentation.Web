using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Repositories
{
    [TestClass]
    public class UserRepositoryTests
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

        #region IRepositoryMembershipProviderRepository Tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ConfirmAccount_WithNameNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IMembershipRepository)new MembershipRepository(null);

            // Act
            var actualResult = repository.ConfirmAccount(username);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_ConfirmAccount_WithNullName_ThrowsArgumentNullException()
        {
            // Arrange
            var repository = (IMembershipRepository)new MembershipRepository(_unitOfWork);

            // Act
            var actualResult = repository.ConfirmAccount(null);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ConfirmAccount_WithNameAndTokenNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String accountConfirmationToken = UserData.UserDave.AccountConfirmationToken;
            var repository = (IMembershipRepository)new MembershipRepository(null);

            // Act
            var actualResult = repository.ConfirmAccount(username, accountConfirmationToken);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_ConfirmAccount_WithNullAccountToken_ThrowsArgumentNullException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IMembershipRepository)new MembershipRepository(_unitOfWork);

            // Act
            var actualResult = repository.ConfirmAccount(username, null);

            // Assert
            // Exception thrown
        }

        [TestMethod]
        public void Test_ConfirmAccount_WithUsernameAndAccountToken_ThrowsArgumentNullException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String accountConfirmationToken = UserData.UserDave.AccountConfirmationToken;
            var repository = (IMembershipRepository)new MembershipRepository(_unitOfWork);

            // Act
            var actualResult = repository.ConfirmAccount(username, accountConfirmationToken);

            // Assert

        }

        //[Ignore]
        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        //public void Test_ValidateUserWithNullUnitOfWork_ThrowsInvalidOperationException()
        //{
        //    // Arrange
        //    const String username = UserData.UserDave.Username;
        //    const String password = UserData.UserDave.Password;
        //    var repository = (IMembershipRepository)new MembershipRepository(null);

        //    // Act
        //    var actualResult = repository.ValidateUser(username, password);

        //    // Assert
        //    // Exception thrown
        //}

        //[Ignore]
        //[TestMethod]
        //public void Test_ValidateUserWithValidUsernameAndPasswordCombination_ReturnsTrue()
        //{
        //    // Arrange
        //    const String username = UserData.UserDave.Username;
        //    const String password = UserData.UserDave.Password;
        //    var repository = (IMembershipRepository)new MembershipRepository(_unitOfWork);

        //    // Act
        //    var actualResult = repository.ValidateUser(username, password);

        //    // Assert
        //    Assert.IsTrue(actualResult);
        //}

        //[Ignore]
        //[TestMethod]
        //public void Test_ValidateUserWithInvalidUsernameAndPasswordCombination_ReturnsFalse()
        //{
        //    // Arrange
        //    const String username = UserData.UserDave.Username;
        //    const String password = UserData.UserJane.Password;
        //    var repository = (IMembershipRepository)new MembershipRepository(_unitOfWork);

        //    // Act
        //    var actualResult = repository.ValidateUser(username, password);

        //    // Assert
        //    Assert.IsFalse(actualResult);
        //}

        #endregion

        #endregion
    }
}
