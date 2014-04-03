using Dibware.Template.Core.Domain.Entities.Accounting;
using Dibware.Template.Core.Domain.Enumerations;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    public interface IAccountStatusService
    {
        /// <summary>
        /// Changes the status.
        /// </summary>
        /// <param name="currentAccountStatus">The current account status.</param>
        /// <param name="requestedAccountStatus">The requested account status.</param>
        /// <param name="rules">The rules which are used to apply restrictions when changing.</param>
        void ChangeStatus(out AccountStatus currentAccountStatus,
            AccountStatus requestedAccountStatus,
            IEnumerable<AccountStatusChangeRule> rules);
    }
}