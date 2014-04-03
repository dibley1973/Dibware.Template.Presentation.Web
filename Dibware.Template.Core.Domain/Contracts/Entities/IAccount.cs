using System;
using Dibware.Template.Core.Domain.Contracts.Entities.Base;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Enumerations;

namespace Dibware.Template.Core.Domain.Contracts.Entities
{
    public interface IAccount : IBaseGuidEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status of the account.
        /// </summary>
        /// <value>
        /// The account status.
        /// </value>
        AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date deleted.
        /// </summary>
        /// <value>
        /// The date deleted.
        /// </value>
        DateTime DateDeleted { get; set; }

        /// <summary>
        /// Gets or sets the date last activated.
        /// </summary>
        /// <value>
        /// The date last activated.
        /// </value>
        DateTime DateLastActivated { get; set; }

        /// <summary>
        /// Gets or sets the date last deactivated.
        /// </summary>
        /// <value>
        /// The date last deactivated.
        /// </value>
        DateTime DateLastDeactivated { get; set; }

        DateTime DateLastPutOnHold { get; set; }

        /// <summary>
        /// Gets or sets the account status service.
        /// </summary>
        /// <value>
        /// The status service.
        /// </value>
        IAccountStatusService StatusService { get; set; }

        /// <summary>
        /// Gets or sets the (foreign key) unique identifier for the user.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        Guid UserGuid { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Changes the status.
        /// </summary>
        /// <param name="requestedAccountStatus">The requested account status.</param>
        void ChangeStatus(AccountStatus requestedAccountStatus);

        #endregion
    }
}
