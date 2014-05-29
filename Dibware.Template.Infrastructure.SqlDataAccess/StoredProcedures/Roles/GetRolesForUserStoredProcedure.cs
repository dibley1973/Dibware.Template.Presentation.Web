using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Roles
{
    public class GetRolesForUserStoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<String>
    {
        public const String ProcedureName = @"UsersInRoles_GetForUser";
        

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordStoredProcedure"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public GetRolesForUserStoredProcedure(String username)
            : base(SchemaNames.Security, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username }
                })
        { }
    }
}