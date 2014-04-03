using Dibware.Template.Core.Application.Services;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Accounting;
using Dibware.Template.Core.Domain.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Application.Tests.Services
{
    [TestClass]
    public class AccountStatusServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_ChangeStatuswithNullRules_ThrowsArgumentNullException()
        {
            // Arrange
            var service = (IAccountStatusService)new AccountStatusService();
            AccountStatus currentStatus;
            const AccountStatus requestedStatus = AccountStatus.Confirmed;

            // Act
            service.ChangeStatus(out currentStatus, requestedStatus, null);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_ChangeStatuswithEmptyRules_ThrowsArgumentNullException()
        {
            // Arrange
            var service = (IAccountStatusService)new AccountStatusService();
            AccountStatus currentStatus;
            const AccountStatus requestedStatus = AccountStatus.Confirmed;
            var rules = new List<AccountStatusChangeRule>();

            // Act
            service.ChangeStatus(out currentStatus, requestedStatus, rules);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ChangeStatusWithValidRules_ThrowsNotImplementedException()
        {
            // Arrange
            var service = (IAccountStatusService)new AccountStatusService();
            AccountStatus currentStatus;
            const AccountStatus requestedStatus = AccountStatus.Confirmed;
            var rules = new List<AccountStatusChangeRule>
            {
                new AccountStatusChangeRule(1,2),
                new AccountStatusChangeRule(2,3),
            };
            // Act
            service.ChangeStatus(out currentStatus, requestedStatus, rules);

            // Assert
            // Exception should be thrown
        }
    }
}
