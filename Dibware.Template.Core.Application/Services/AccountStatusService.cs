using System.Linq;
using Dibware.Helpers.Validation;
using Dibware.Template.Core.Application.Resources;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Accounting;
using Dibware.Template.Core.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Application.Services
{
    public class AccountStatusService : IAccountStatusService
    {
        /// <summary>
        /// Changes the status.
        /// </summary>
        /// <param name="currentAccountStatus">The current account status.</param>
        /// <param name="requestedAccountStatus">The requested account status.</param>
        /// <param name="rules">The rules which are used to apply restrictions when changing.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ChangeStatus(out AccountStatus currentAccountStatus,
            AccountStatus requestedAccountStatus,
            IEnumerable<AccountStatusChangeRule> rules)
        {
            Guard.ArgumentIsNotNull(rules, "rules");
            Guard.ArgumentOutOfRange((!rules.Any()), "rules", ExceptionMessages.RulesNotEmpty);

            throw new NotImplementedException();
        }
    }
}