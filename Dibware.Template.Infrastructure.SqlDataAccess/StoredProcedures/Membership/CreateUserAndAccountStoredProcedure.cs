using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_CreateUserAndAccount stored procedure
    /// </summary>
    public class CreateUserAndACreateUserAndMembershipStoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<String>
    {
        public const String ProcedureName = @"Membership_CreateUserAndMembership";
        public const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordStoredProcedure" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmationToken">The confirmation token.</param>
        public CreateUserAndACreateUserAndMembershipStoredProcedure(
            String username,
            String name,
            String password,
            String confirmationToken)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "name", name },
                    { "password", password },
                    { "confirmationToken", confirmationToken }
                })
        { }
    }
}