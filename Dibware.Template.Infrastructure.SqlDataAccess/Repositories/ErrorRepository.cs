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
    public class ErrorRepository : Repository<Error>, IErrorRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ErrorRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion
    }
}