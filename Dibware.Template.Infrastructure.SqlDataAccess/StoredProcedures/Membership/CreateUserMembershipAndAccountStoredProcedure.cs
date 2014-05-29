using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_CreateUserMembershipAndAccount stored procedure
    /// </summary>
    public class CreateUserMembershipAndAccountStoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<String>
    {
        public const String ProcedureName = @"Membership_CreateUserMembershipAndAccount";
        

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserMembershipAndAccountStoredProcedure" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmationToken">The confirmation token.</param>
        public CreateUserMembershipAndAccountStoredProcedure(
            String username,
            String name,
            String password,
            String emailAddress,
            String confirmationToken)
            : base(SchemaNames.Security, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "name", name },
                    { "password", password },
                    { "emailAddress", emailAddress },
                    { "confirmationToken", confirmationToken }
                })
        { }
    }
}