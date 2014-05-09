using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Mocks
{
    public static class MockSqlExceptionHelper
    {
        /// <summary>
        /// Creates the SQL excpetion.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static SqlException CreateSqlException(Int32 LineNumber, Int32 number, String message)
        {
            String dummyServer = "Dummy Server";
            String dummyProcedure = "Dummy procedure";
            Byte defaultState = 2;
            Byte defaultClass = 3;
            SqlErrorCollection collection = ObjectInstanciator.Construct<SqlErrorCollection>(0);
            object[] errorConstructorParameters = new object[] { number, defaultState, defaultClass, dummyServer, message, dummyProcedure, LineNumber };
            SqlError error = ObjectInstanciator.Construct<SqlError>(0, errorConstructorParameters);

            typeof(SqlErrorCollection)
                .GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(collection, new object[] { error });

            MethodInfo methodInfo = typeof(SqlException)
                .GetMethod(
                    "CreateException",
                    (BindingFlags.NonPublic | BindingFlags.Static),
                    null,
                    CallingConventions.ExplicitThis,
                    new[] { typeof(SqlErrorCollection), typeof(string) },
                    new ParameterModifier[] { });

            var exception = methodInfo.Invoke(null, new object[] { collection, "7.0.0" }) as SqlException;
            return exception;
        }
    }
}