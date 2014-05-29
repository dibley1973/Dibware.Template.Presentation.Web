using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Terms;
using System;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class TermAndConditionRepository : Repository<TermAndCondition>, ITermAndConditionRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="TermAndConditionRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public TermAndConditionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        /// <summary>
        /// Gets the current terms and conditions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TermAndCondition GetCurrent()
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            try
            {
                var procedure = new GetCurrentTermsStoredProcedure();
                var results = UnitOfWork.ExecuteStoredProcedure<TermAndCondition>(procedure);
                var returnValue = results.FirstOrDefault();
                return returnValue;
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debuggung is complete
                throw ex;
            }
        }
    }
}