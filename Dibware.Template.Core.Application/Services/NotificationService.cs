using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Application;
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
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Notification> GetAllCurrentForUser(string username)
        {
            return _termAndConditionRepository.GetAllCurrentForUser(username);
        }

        #endregion
    }
}