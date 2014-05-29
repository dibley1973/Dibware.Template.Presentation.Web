using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership
{
    internal abstract class BaseMembershipStoredProcedure<TResult> : BaseStoredProcedure<TResult>, IStoredProcedure<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMembershipStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        internal BaseMembershipStoredProcedure(string name)
            : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMembershipStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        internal BaseMembershipStoredProcedure(string name, IDictionary<string, object> parameters)
            : base(name, parameters) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMembershipStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name.</param>
        internal BaseMembershipStoredProcedure(string schema, string name)
            : base(schema, name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMembershipStoredProcedure{TResult}"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        internal BaseMembershipStoredProcedure(string schema, string name, IDictionary<string, object> parameters)
            : base(schema, name, parameters) { }
    }
}