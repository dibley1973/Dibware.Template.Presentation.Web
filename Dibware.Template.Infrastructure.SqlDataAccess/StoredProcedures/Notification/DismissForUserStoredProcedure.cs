using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Notification
{
    /// <summary>
    /// Represents the application.Notifications_DismissByIdForUser stored procedure
    /// </summary>
    public class DismissForUserStoredProcedure : BaseStoredProcedure<Int32>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Notifications_DismissByIdForUser";

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordStoredProcedure"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public DismissForUserStoredProcedure(Int32 notificationId, String username)
            : base(SchemaNames.Application, ProcedureName, new Dictionary<String, Object>()
                {
                    { "notificationId", notificationId },
                    { "username", username }
                })
        { }
    }
}