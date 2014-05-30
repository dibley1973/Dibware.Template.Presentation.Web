using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;
using Entities = Dibware.Template.Core.Domain.Entities;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Notification
{
    /// <summary>
    /// Represents the application.Notifications_GetForUser stored procedure
    /// </summary>
    public class GetCurrentNotificationsForUserStoredProcedure : BaseStoredProcedure<Entities.Application.Notification>, IStoredProcedure<Entities.Application.Notification>
    {
        public const String ProcedureName = @"Notifications_GetForUser";

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordStoredProcedure"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public GetCurrentNotificationsForUserStoredProcedure(String username)
            : base(SchemaNames.Application, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username }
                })
        { }
    }
}