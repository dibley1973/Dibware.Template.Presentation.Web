using Dibware.Template.Core.Application.Services;
using Dibware.Template.Core.Application.Tests.MockData;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Accounting;
using Dibware.Template.Core.Domain.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Application.Tests.Services
{
    [TestClass]
    public class PasswordServiceTests
    {
        #region Fields

        private PasswordService _passwordService;

        #endregion

        #region Initialization

        [TestInitialize]
        public void TestInitialize()
        {
            _passwordService = new PasswordService(
                PasswordData.InitialData.HashByteSize,
                PasswordData.InitialData.SaltByteSize,
                PasswordData.InitialData.Pbkdf2Iterations,
                PasswordData.InitialData.ConfirmationTokenLength,
                PasswordData.InitialData.MinRequiredPasswordLength,
                PasswordData.InitialData.MinRequiredNonAlphanumericCharacters,
                PasswordData.InitialData.PasswordStrengthRegularExpression
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

        #endregion
    }
}
