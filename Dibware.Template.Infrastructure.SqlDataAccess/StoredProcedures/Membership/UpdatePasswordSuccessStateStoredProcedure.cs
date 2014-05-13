﻿using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    /// <summary>
    /// Represents the security.Membership_UpdatePasswordSuccessState stored procedure
    /// </summary>
    public class UpdatePasswordSuccessStateStoredProcedure : BaseStoredProcedure<Boolean>, IStoredProcedure<Int32>
    {
        public const String ProcedureName = @"Membership_UpdatePasswordSuccessState";
        public const String ProcedureSchema = @"security";

        /// <summary>
        /// Initializes a new instance of the <see cref="IsConfirmedStoredProcedure" /> class.
        /// </summary>
        /// <param name="userGuid">The username for the user.</param>
        public UpdatePasswordSuccessStateStoredProcedure(String username)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username }
                })
        { }
    }
}
