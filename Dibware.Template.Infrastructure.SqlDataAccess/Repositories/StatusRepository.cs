using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public StatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion
    }
}