using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_ResetPassword stored procedure
    /// </summary>
    internal class ResetPasswordWithTokenStoredProcedure : BaseMembershipStoredProcedure<Int32>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Membership_ResetPassword";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="passwordConfirmationToken">The password confirmation token.</param>
        /// <param name="newHashedPassword">The new hashed password.</param>
        public ResetPasswordWithTokenStoredProcedure(
            String passwordConfirmationToken, String newHashedPassword)
            : base(SchemaNames.Security, ProcedureName, new Dictionary<String, Object>()
                {
                    { "passwordConfirmationToken", passwordConfirmationToken },
                    { "newPassword", newHashedPassword }
                })
        { }
    }
}
