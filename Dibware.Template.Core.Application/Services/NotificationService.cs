using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Application;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Application.Services
{
    /// <summary>
    /// Represents the service used for interacting with Notification data
    /// </summary>
    public class NotificationService : INotificationService
    {
        #region Decalarations

        private INotificationRepository _termAndConditionRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="NotificationService"/> service
        /// </summary>
        /// <param name="termAndConditionRepository">
        /// An instance of an object that implements <see cref="INotificationRepository"/> repository
        /// </param>
        public NotificationService(INotificationRepository termAndConditionRepository)
        {
            _termAndConditionRepository = termAndConditionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dismissed the notifcation specified by Id for the specified user
        /// </summary>
        /// <param name="notificationId">The ID of the notifcation to dismiss</param>
        /// <param name="username">The name of the user to dimiss the notifcation for</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool DismissForUser(Int32 notificationId, String username)
        {
            return _termAndConditionRepository.DismissForUser(notificationId, username);
        }

        /// <summary>
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Notification> GetAllCurrentForUser(String username)
        {
            return _termAndConditionRepository.GetAllCurrentForUser(username);
        }

        #endregion


    }
}