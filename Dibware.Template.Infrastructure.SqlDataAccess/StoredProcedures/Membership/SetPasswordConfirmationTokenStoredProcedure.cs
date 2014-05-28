using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_SetPasswordConfirmationToken stored procedure
    /// </summary>
    internal class SetPasswordConfirmationTokenStoredProcedure : BaseMembershipStoredProcedure<Int32>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Membership_SetPasswordConfirmationToken";
        public new const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwordConfirmationToken">The password confirmation token.</param>
        /// <param name="tokenExpirationTime">The token expiration time.</param>
        public SetPasswordConfirmationTokenStoredProcedure(
            String username,
            String passwordConfirmationToken,
            DateTime tokenExpirationTime)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "passwordConfirmationToken", passwordConfirmationToken },
                    { "tokenExpirationTime", tokenExpirationTime }
                })
        { }
    }
}