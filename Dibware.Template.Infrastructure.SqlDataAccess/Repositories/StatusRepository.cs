using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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