using Dibware.Template.Core.Domain.Exceptions;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.HelperTests
{
    [TestClass]
    public class SqlExceptionHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Test_HandleKnownSqlExceptions_HandlingUnknown_ResultsIn_SqlExceptionRethrown()
        {
            // Arrange
            Int32 lineNumber = 100;
            Int32 unknownExceptionNumber = 49999;
            String message = "UnknownException";
            SqlException exception =
                MockSqlExceptionHelper.CreateSqlException(lineNumber, unknownExceptionNumber, message);

            // Act
            throw SqlExceptionHelper.HandledKnownSqlExceptions(exception);

            // Asssert
            // Exception expected
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Test_HandleKnownSqlExceptions_HandlingUnknown_ResultsIn_ValidationExceptionThrown()
        {
            // Arrange
            Int32 lineNumber = 100;
            Int32 knownExceptionNumber =
                (Int32)SqlExceptionNumbers.MembershipHasAlreadyConfirmed;
            String message = "Membership has already been confirmed";
            SqlException exception =
                MockSqlExceptionHelper.CreateSqlException(lineNumber, knownExceptionNumber, message);

            // Act
            throw SqlExceptionHelper.HandledKnownSqlExceptions(exception);

            // Asssert
            // Exception expected
        }
    }
}
