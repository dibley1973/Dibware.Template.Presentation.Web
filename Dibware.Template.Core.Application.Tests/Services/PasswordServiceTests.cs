using Dibware.Extensions.System.Collections;
using Dibware.Template.Core.Application.Services;
using Dibware.Template.Core.Application.Tests.MockData;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Entities.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dibware.Template.Core.Application.Tests.Services
{
    [TestClass]
    public class PasswordServiceTests
    {
        #region Fields

        private List<PasswordStrengthRule> _allRulesList;
        private PasswordService _passwordService;
        private Mock<IPasswordStrengthRuleRepository> _passwordStrengthRuleRepository;

        #endregion

        #region Initialization

        [TestInitialize]
        public void TestInitialize()
        {
            // Mock all password strength rules array
            _allRulesList = new List<PasswordStrengthRule>()
            { 
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule1.Id,
                    Description = PasswordStrengthRuleData.Rule1.Description,
                    Notes = PasswordStrengthRuleData.Rule1.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule1.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule2.Id,
                    Description = PasswordStrengthRuleData.Rule2.Description,
                    Notes = PasswordStrengthRuleData.Rule2.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule2.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule3.Id,
                    Description = PasswordStrengthRuleData.Rule3.Description,
                    Notes = PasswordStrengthRuleData.Rule3.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule3.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule4.Id,
                    Description = PasswordStrengthRuleData.Rule4.Description,
                    Notes = PasswordStrengthRuleData.Rule4.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule4.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule5.Id,
                    Description = PasswordStrengthRuleData.Rule5.Description,
                    Notes = PasswordStrengthRuleData.Rule5.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule5.RegularExpression
                }
            };

            // Mock role repository
            _passwordStrengthRuleRepository = new Mock<IPasswordStrengthRuleRepository>();

            _passwordStrengthRuleRepository
                .Setup(r => r.GetAll())
                .Returns(_allRulesList);

            _passwordStrengthRuleRepository
                .Setup(r => r.GetAllRulesAsRegularExpression())
                .Returns(_allRulesList.Select(r => r.RegularExpression).AppendAll());

            _passwordStrengthRuleRepository
                .Setup(r => r.GetAllRuleRegularExpressions())
                .Returns(_allRulesList.Select(r => r.RegularExpression));

            _passwordService = new PasswordService(
                _passwordStrengthRuleRepository.Object,
                PasswordData.InitialData.HashByteSize,
                PasswordData.InitialData.SaltByteSize,
                PasswordData.InitialData.Pbkdf2Iterations,
                PasswordData.InitialData.ConfirmationTokenLength,
                PasswordData.InitialData.MinRequiredPasswordLength,
                PasswordData.InitialData.MinRequiredNonAlphanumericCharacters
            );
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Test_PasswordService_CreateConfirmationToken_ResultsIn_ValidLengthString()
        {
            // Arrange

            // Act
            var token = _passwordService.CreateConfirmationToken();
            var length = token.Length;

            // Assert
            Assert.AreEqual(PasswordData.InitialData.ConfirmationTokenLength, length);
        }

        [TestMethod]
        public void Test_PasswordService_CreateHash_ResultsIn_ValidLengthString()
        {
            // Arrange
            var password = PasswordData.TestData.ValidPassword;

            // Act
            var fullHash = _passwordService.CreateHash(password);
            String[] split = fullHash.Split(PasswordData.InitialData.DELIMITER);
            Byte[] hash = Convert.FromBase64String(split[PasswordData.InitialData.PBKDF2_INDEX]);

            var length = hash.Length;

            // Assert
            Assert.AreEqual(PasswordData.InitialData.HashByteSize, length);
        }

        [TestMethod]
        public void Test_PasswordService_OnceInstanciated_ResultsIn_CorrectMinRequiredPasswordLength()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(PasswordData.InitialData.MinRequiredPasswordLength, _passwordService.MinRequiredPasswordLength);
        }

        [TestMethod]
        public void Test_PasswordService_OnceInstanciated_ResultsIn_CorrectMinRequiredNonAlphanumericCharacters()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(PasswordData.InitialData.MinRequiredNonAlphanumericCharacters, _passwordService.MinRequiredNonAlphanumericCharacters);
        }

        [TestMethod]
        public void Test_PasswordService_GetPasswordStrengthRegularExpression_ResultsIn_CorrectExpression()
        {
            // Arrange
            String expectedResult = String.Concat (
                PasswordStrengthRuleData.Rule1.RegularExpression,
                PasswordStrengthRuleData.Rule2.RegularExpression,
                PasswordStrengthRuleData.Rule3.RegularExpression,
                PasswordStrengthRuleData.Rule4.RegularExpression,
                PasswordStrengthRuleData.Rule5.RegularExpression
            );

            // Act
            var result = PasswordService.GetPasswordStrengthRegularExpression(
                _passwordStrengthRuleRepository.Object);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion
    }
}
