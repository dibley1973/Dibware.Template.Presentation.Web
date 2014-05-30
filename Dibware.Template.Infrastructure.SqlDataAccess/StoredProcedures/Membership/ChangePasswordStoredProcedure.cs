using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_ChangePassword stored procedure
    /// </summary>
    internal class ChangePasswordStoredProcedure : BaseMembershipStoredProcedure<Int32>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Membership_ChangePassword";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="newHashedPassword">The new hashed password.</param>
        public ChangePasswordStoredProcedure(
            String username,
            String newHashedPassword)
            : base(SchemaNames.Security, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "newPassword", newHashedPassword }
                })
        { }
    }
}