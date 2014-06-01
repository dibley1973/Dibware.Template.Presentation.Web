using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public NotificationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region INotificationRepository Members

        /// <summary>
        /// Dismisses the notification for user.
        /// </summary>
        /// <param name="notificationId">The notification identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Boolean DismissForUser(Int32 notificationId, String username)
        {

            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            // Validate arguments
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            try
            {
                var procedure = new DismissForUserStoredProcedure(notificationId, username);
                var result = UnitOfWork.ExecuteScalarStoredProcedure<Int32>(procedure);
                var returnValue = (result == 1);
                return returnValue;
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debuggung is complete
                throw ex;
            }
        }

        /// <summary>
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public List<Notification> GetAllCurrentForUser(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            // Validate arguments
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            try
            {
                var procedure = new GetCurrentNotificationsForUserStoredProcedure(username);
                var results = UnitOfWork.ExecuteStoredProcedure<Notification>(procedure);
                var returnValue = results.ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debuggung is complete
                throw ex;
            }
        }

        #endregion
    }
}