using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Notification;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Terms;
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

        /// <summary>
        /// Gets all of the current Notifications for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public List<Notification> GetAllCurrentForUser(string username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

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
    }
}