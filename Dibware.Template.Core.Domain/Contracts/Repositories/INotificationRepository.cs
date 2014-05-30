using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Application;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    /// <summary>
    /// Defines the expected members of a Notification Repository
    /// </summary>
    public interface INotificationRepository : IRepository<Notification>
    {
        /// <summary>
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        List<Notification> GetAllCurrentForUser(String username);
    }
}