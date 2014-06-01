using Dibware.Template.Core.Domain.Entities.Application;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    /// <summary>
    /// Defines the expected members of a Notification Service
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Dismissed the notifcation specified by Id for the specified user
        /// </summary>
        /// <param name="notificationId">
        /// The ID of the notifcation to dismiss
        /// </param>
        /// <param name="username">
        /// The name of the user to dimiss the notifcation for
        /// </param>
        /// <returns></returns>
        Boolean DismissForUser(Int32 notificationId, String username);

        /// <summary>
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        List<Notification> GetAllCurrentForUser(String username);
    }
}