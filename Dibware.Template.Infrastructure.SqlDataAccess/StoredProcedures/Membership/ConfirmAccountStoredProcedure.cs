using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_ConfirmAccount stored procedure
    /// </summary>
    public class ConfirmAccountStoredProcedure : BaseStoredProcedure<Int32>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Membership_ConfirmAccount";
        

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <param name="username">The username, null or empty string.</param>
        public ConfirmAccountStoredProcedure(
            String confirmationToken,
            String username = "")
            : base(SchemaNames.Security, ProcedureName, new Dictionary<String, Object>()
                {
                    { "confirmationToken", confirmationToken },
                    { "username", (String.IsNullOrEmpty(username) ? String.Empty : username) }
                })
        { }
    }
}