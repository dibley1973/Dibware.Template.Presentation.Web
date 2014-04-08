using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Security;

namespace Dibware.Template.Presentation.Web.Tests.HelperTests
{
    [TestClass]
    public class MembershipHelperTests
    {
        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithDuplicateUserNameStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.DuplicateUserName;
            var expectedValue = MembershipCreateStatusErrorMessages.DuplicateUserName;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithDuplicateEmailStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.DuplicateEmail;
            var expectedValue = MembershipCreateStatusErrorMessages.DuplicateEmail;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithInvalidPasswordStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidPassword;
            var expectedValue = MembershipCreateStatusErrorMessages.InvalidPassword;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithInvalidEmailStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidEmail;
            var expectedValue = MembershipCreateStatusErrorMessages.InvalidEmail;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithInvalidAnswerStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidAnswer;
            var expectedValue = MembershipCreateStatusErrorMessages.InvalidAnswer;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithInvalidQuestionStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidQuestion;
            var expectedValue = MembershipCreateStatusErrorMessages.InvalidQuestion;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithInvalidUserNameStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidUserName;
            var expectedValue = MembershipCreateStatusErrorMessages.InvalidUserName;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithProviderErrorStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.ProviderError;
            var expectedValue = MembershipCreateStatusErrorMessages.ProviderError;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithUserRejectedStatus_ReturnsCorrectValue()
        {
            // Arrange
            var status = MembershipCreateStatus.UserRejected;
            var expectedValue = MembershipCreateStatusErrorMessages.UserRejected;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        //[TestMethod]
        //public void Test_ConvertErrorCodeToStringWith Status_ReturnsCorrectValue()
        //{
        //    // Arrange
        //    var status = MembershipCreateStatus.;
        //    var expectedValue = MembershipCreateStatusErrorMessages.;

        //    // Act
        //    var result = MembershipHelper.ConvertErrorCodeToString(status);

        //    // Assert
        //    Assert.AreEqual(expectedValue, result);
        //}

        [TestMethod]
        public void Test_ConvertErrorCodeToStringWithUnknownStatus_ReturnsDefaultValue()
        {
            // Arrange
            var status = MembershipCreateStatus.InvalidProviderUserKey;
            var expectedValue = MembershipCreateStatusErrorMessages.Default;

            // Act
            var result = MembershipHelper.ConvertErrorCodeToString(status);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}