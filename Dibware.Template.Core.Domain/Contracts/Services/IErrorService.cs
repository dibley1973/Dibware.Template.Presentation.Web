using Dibware.Template.Core.Domain.Entities.Application;
using System;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    public interface IErrorService : IDataService<Error>
    {
        /// <summary>
        /// Logs the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        void LogError(Error error);

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="username">The username who the exception happend to.</param>
        void LogException(Exception ex, String username);
    }
}