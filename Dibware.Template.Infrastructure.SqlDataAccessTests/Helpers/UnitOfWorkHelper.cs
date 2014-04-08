using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using System;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers
{
    internal static class UnitOfWorkHelper
    {
        /// <summary>
        /// Appends the database folder to the specified path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        private static void AppendDatabaseFolder(ref String folderPath)
        {
            folderPath = String.Concat(folderPath, @"\Database");
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>The TemplateDbContext</returns>
        internal static WebsiteDbContext GetUnitOfWork()
        {
            var folderPath = ThisAssembly.GetProjectDirectory();
            AppendDatabaseFolder(ref folderPath);

            folderPath = @"C:\temp\";
            var connectionStringFormatString = Properties.Settings.Default.TestConnection;
            var connectionString = String.Format(connectionStringFormatString, folderPath);
            return new WebsiteDbContext(connectionString);
        }

        /// <summary>
        /// Gets the unit of work that is empty.
        /// </summary>
        /// <returns>An empty TemplateDbContext</returns>
        internal static WebsiteDbContext GetUnitOfWorkEmpty()
        {
            var folderPath = ThisAssembly.GetProjectDirectory();
            AppendDatabaseFolder(ref folderPath);

            folderPath = @"C:\temp\";
            var connectionStringFormatString = Properties.Settings.Default.TestConnectionEmpty;
            var connectionString = String.Format(connectionStringFormatString, folderPath);
            return new WebsiteDbContext(connectionString);
        }
    }
}
