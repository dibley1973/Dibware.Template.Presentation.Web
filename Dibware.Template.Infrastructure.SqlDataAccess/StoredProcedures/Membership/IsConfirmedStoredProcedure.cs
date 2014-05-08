using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_IsConfirmed stored procedure
    /// </summary>
    public class IsConfirmedStoredProcedure : BaseStoredProcedure<Boolean>, IStoredProcedure<Boolean>
    {
        public const String ProcedureName = @"Membership_IsConfirmed";
        public const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="IsConfirmedStoredProcedure" /> class.
        /// </summary>
        /// <param name="userGuid">The username for the user.</param>
        public IsConfirmedStoredProcedure(String username)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username }
                })
        { }
    }
}