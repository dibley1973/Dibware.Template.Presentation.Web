using Dibware.Template.Core.Domain.Entities.Base;
using System;

namespace Dibware.Template.Core.Domain.Entities.Application
{
    /// <summary>
    /// Represents an error of the system
    /// </summary>
    public class Error : BaseIdEntity
    {
        #region Properties

        public String Message { get; set; }

        public String Source { get; set; }

        public String StackTrace { get; set; }

        public String Username { get; set; }

        public DateTime TimeStamp { get; set; }

        #endregion 

        #region Constructors

        /// <summary>
        /// Creates a new instance of the Error object
        /// </summary>
        /// <param name="ex">The Exception encountered.</param>
        /// <param name="username">The name of the user who encountered the Exception.</param>
        /// <param name="timeStamp">The timestamp when the Exception was encountered.</param>
        public Error(Exception ex, String username, DateTime timeStamp) :
            this(ex.Message, ex.Source, ex.StackTrace, username, timeStamp) { }

        /// <summary>
        /// Creates a new instance of the Error object
        /// </summary>
        /// <param name="message">The error message encountered.</param>
        /// <param name="source">The source of the error encountered.</param>
        /// <param name="stackTrace">The stacktrace of the error encounted.</param>
        /// <param name="username">The name of the user who encountered the Exception.</param>
        /// <param name="timeStamp">The timestamp when the Exception was encountered.</param>
        public Error(String message, String source, String stackTrace, 
            String username, DateTime timeStamp)
        {
            Message = message;
            Source = source;
            StackTrace = stackTrace;
            Username = username;
            TimeStamp = timeStamp;
        }

        #endregion
    }
}