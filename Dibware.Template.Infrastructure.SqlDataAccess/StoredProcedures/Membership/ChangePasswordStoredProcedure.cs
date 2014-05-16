using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
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
        public new const String ProcedureSchema = @"security";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <param name="username">The username, null or empty string.</param>
        public ChangePasswordStoredProcedure(
            String username,
            String newHashedPassword)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "newHashedPassword", newHashedPassword }
                })
        { }
    }
}
