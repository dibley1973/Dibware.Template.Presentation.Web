using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    public class ValidateUser : BaseStoredProcedure<String>, IStoredProcedure<Boolean>
    {
        public const String ProcedureName = "Validate";
        public const String ProcedureSchema = @"security";

        public ValidateUser(String username, String password)
            : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                {
                    { "username", username },
                    { "password", password }
                })
        {}
    }
}