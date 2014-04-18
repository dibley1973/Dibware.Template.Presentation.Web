using Dibware.Template.Core.Application.Base;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Application;
using System;

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

        #region IErrorService Members

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LogError(Error error)
        {
            base.AddNew(error);
        }

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="username">The username who the exception happend to.</param>
        public void LogException(Exception ex, String username)
        {
            var error = new Error(ex, username, DateTime.Now);
            LogError(error);
        }

        #endregion
    }
}