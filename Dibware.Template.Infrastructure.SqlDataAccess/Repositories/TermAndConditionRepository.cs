using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;

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
            throw new System.NotImplementedException();
        }
    }
}