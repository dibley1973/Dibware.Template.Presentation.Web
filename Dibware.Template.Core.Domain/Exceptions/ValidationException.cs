using System;

namespace Dibware.Template.Core.Domain.Exceptions
{
    /// <summary>
    /// Encapsualtes validation exception information
    /// </summary>
    public class ValidationException : ApplicationException
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        public ValidationException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public ValidationException(String message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ValidationException(String message, Exception innerException) : base(message, innerException) { }

        #endregion
    }
}