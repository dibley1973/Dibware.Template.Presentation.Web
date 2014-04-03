using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Resources;
using System;

namespace Dibware.Template.Core.Domain.Entities.Accounting
{
    /// <summary>
    /// Encapsulates a rule for changing an AccountStatus
    /// </summary>
    public class AccountStatusChangeRule
    {
        #region Properties

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        private Int32 CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets a status that can be changed to.
        /// </summary>
        /// <value>
        /// An allowed status.
        /// </value>
        private Int32 AllowedStatus { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatusChangeRule"/> class.
        /// </summary>
        /// <param name="currentStatus">The current status.</param>
        /// <param name="allowedStatus">The allowed status.</param>
        public AccountStatusChangeRule(Int32 currentStatus, Int32 allowedStatus)
        {
            Guard.ArgumentOutOfRange((currentStatus == allowedStatus), "allowedStatus", ExceptionMessages.AllowedStatusEqualsCurrentStatus);
            CurrentStatus = currentStatus;
            AllowedStatus = allowedStatus;
        }

        #endregion
    }
}