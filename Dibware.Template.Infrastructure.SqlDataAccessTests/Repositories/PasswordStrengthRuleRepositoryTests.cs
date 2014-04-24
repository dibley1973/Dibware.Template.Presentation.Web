using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Repositories
{
    [TestClass]
    public class PasswordStrengthRuleRepositoryTests
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

        #endregion Test 

        #region Tests

        #region IPasswordStrengthRuleRepository

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PasswordStrengthRuleRepository_GetAllWithNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            var repository = (IPasswordStrengthRuleRepository)new PasswordStrengthRuleRepository(null);

            // Act
            var actualResult = repository.GetAll();

            // Assert
            // Exception Thrown
        }

        [TestMethod]
        public void Test_PasswordStrengthRuleRepository_GetAllWithValidUnitOfWork_ResultsIn_AllRulesReturned()
        {
            // Arrange
            const Int32 expectedCount = 5;
            var repository = (IPasswordStrengthRuleRepository)new PasswordStrengthRuleRepository(_unitOfWork);

            // Act
            var actualResult = repository.GetAll();

            // Assert
            Assert.AreEqual(expectedCount, actualResult.Count);
        }

        [TestMethod]
        public void Test_PasswordStrengthRuleRepository_GetAllRuleRegularExpressionsWithValidUnitOfWork_ResultsIn_AllRulesRegularExpressionsReturned()
        {
            // Arrange
            const Int32 expectedCount = 5;
            var repository = (IPasswordStrengthRuleRepository)new PasswordStrengthRuleRepository(_unitOfWork);

            // Act
            var results = repository.GetAllRuleRegularExpressions();
            var allRegexString = results.Aggregate((current, next) => current + next);

            // Assert
            Assert.IsTrue(allRegexString.Contains(PasswordStrengthRuleData.Rule1.RegularExpression));
            Assert.IsTrue(allRegexString.Contains(PasswordStrengthRuleData.Rule2.RegularExpression));
            Assert.IsTrue(allRegexString.Contains(PasswordStrengthRuleData.Rule3.RegularExpression));
            Assert.IsTrue(allRegexString.Contains(PasswordStrengthRuleData.Rule4.RegularExpression));
            Assert.IsTrue(allRegexString.Contains(PasswordStrengthRuleData.Rule5.RegularExpression));
        }
        #endregion

        #endregion
    }
}
