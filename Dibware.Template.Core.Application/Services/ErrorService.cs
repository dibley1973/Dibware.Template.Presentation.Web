using Dibware.Template.Core.Application.Base;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Application.Services
{
    public class ErrorService : DataService<Error>, IErrorService
    {
        #region Private Members

        //private IErrorRepository _errorRepository;

        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorService" /> class.
        /// </summary>
        /// <param name="errorRepository">The error repository.</param>
        public ErrorService(IErrorRepository errorRepository)
            : base(errorRepository)
        {
            //this._errorRepository = errorRepository;
        }

        #endregion
    }
}
