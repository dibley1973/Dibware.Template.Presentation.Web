using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_ConfirmAccount stored procedure
    /// </summary>
    public class ConfirmAccountStoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<Boolean>
    {
        public const String ProcedureName = @"Membership_ConfirmAccount";
        public const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <param name="username">The username, null or empty string.</param>
        public ConfirmAccountStoredProcedure(
            String confirmationToken,
            String username = "")
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "confirmationToken", confirmationToken },
                    { "username", (String.IsNullOrEmpty(username) ? String.Empty : username) }
                })
        { }
    }
}