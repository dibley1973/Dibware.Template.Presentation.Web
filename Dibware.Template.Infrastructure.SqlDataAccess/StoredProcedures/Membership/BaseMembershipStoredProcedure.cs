using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    internal abstract class BaseMembershipStoredProcedure<TResult> : BaseStoredProcedure<TResult>, IStoredProcedure<TResult>
    {
        public const String ProcedureSchema = @"security";

        internal BaseMembershipStoredProcedure(string name) 
            : base(name) { }
        internal BaseMembershipStoredProcedure(string name, IDictionary<string, object> parameters)
            : base(name, parameters) { }
        internal BaseMembershipStoredProcedure(string schema, string name)
            : base(schema, name) { }
        internal BaseMembershipStoredProcedure(string schema, string name, IDictionary<string, object> parameters)
            : base(schema, name, parameters) { }
        
    }
}