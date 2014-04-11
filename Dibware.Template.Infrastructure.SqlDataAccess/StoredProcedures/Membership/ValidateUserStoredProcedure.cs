using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_ValidateUser stored procedure
    /// </summary>
    public class ValidateUserStoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<Boolean>
    {
        public const String ProcedureName = @"Membership_ValidateUser";
        public const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUserStoredProcedure"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public ValidateUserStoredProcedure(String username, String password)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "password", password }
                })
        { }
    }
}