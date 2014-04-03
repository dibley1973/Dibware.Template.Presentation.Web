using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Helpers
{
    /// <summary>
    /// Helper class to encourage consistence of naming conventions
    /// </summary>
    public static class DatabaseObjectNameHelper
    {
        /// <summary>
        /// Gets the full name of the table.
        /// </summary>
        /// <param name="schemaName">Name of the schema.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public static String GetFullTableName(String schemaName, String tableName)
        {
            return String.Format(StringFormats.SchameObject, schemaName, tableName);
        }

        /// <summary>
        /// Gets the full name of the stored procedure.
        /// </summary>
        /// <param name="schemaName">Name of the schema.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static String GetFullStoredProcedureName(String schemaName,
            String tableName, String action)
        {
            return String.Format(
                StringFormats.StoredProcedureName,
                schemaName,
                tableName,
                action);
        }
    }
}