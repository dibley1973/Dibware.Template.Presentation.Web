using Dibware.EF.Extensions.Base;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;

namespace Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Terms
{
    /// <summary>
    /// Represents the application.TermAndCondition_GetCurrent stored procedure
    /// </summary>
    public class GetCurrentTermsStoredProcedure : BaseStoredProcedure<TermAndCondition>, IStoredProcedure<TermAndCondition>
    {
        public const String ProcedureName = @"TermAndCondition_GetCurrent";
        //public const String ProcedureSchema = @"application";

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordStoredProcedure"/> class.
        /// </summary>
        public GetCurrentTermsStoredProcedure()
            : base(SchemaNames.Application, ProcedureName)
        { }
    }
}