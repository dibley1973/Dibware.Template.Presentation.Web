using Dibware.Template.Core.Domain.Exceptions;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Data.SqlClient;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Helpers
{
    public static class SqlExceptionHelper
    {
        /// <summary>
        /// Handles known SQL exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static Exception HandledKnownSqlExceptions(SqlException exception)
        {
            // Determine if the Sql Exception number is a know value
            if (!typeof(SqlExceptionNumbers).IsEnumDefined(exception.Number))
            {
                // If it is not just return it
                return exception;
            }

            // Otherwise cast it so we can handle it
            SqlExceptionNumbers sqExNumber = (SqlExceptionNumbers)exception.Number;

            // Catch explicit Sql Exceptions that we are aware we need to 
            // handle and rethrow them as a more appropriate Exception type
            switch (sqExNumber)
            {
                // Catch any Sql Exceptions that are in essence validation errors 
                case SqlExceptionNumbers.EmailAddressAlreadyExists:
                case SqlExceptionNumbers.UserNameAlreadyExists:
                case SqlExceptionNumbers.MembershipHasAlreadyConfirmed:
                case SqlExceptionNumbers.UsernameDoesNotExist:
                    // ...return them as ValidationExceptions
                    return new ValidationException(exception.Message, exception);


                // If the exception is not in our handled list...
                default:
                    // ...then just return it as it is
                    return exception;
            }
        }
    }
}