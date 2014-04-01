using System;
using System.IO;
using System.Reflection;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers
{
    /// <summary>
    /// Helper class for Assembly based operations
    /// </summary>
    public static class ThisAssembly
    {
        /// <summary>
        /// Gets the project directory.
        /// </summary>
        /// <returns />
        public static String GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectoryInfo = Directory.GetParent(currentDirectory).Parent;
            if (parentDirectoryInfo == null)
            {
                var errorMessage = "parentDirectoryInfo must not be null";
                throw new NullReferenceException(errorMessage);
            }
            var projectDirectory = parentDirectoryInfo.FullName;
            return projectDirectory;
        }

        /// <summary>
        /// Gets the executing directory.
        /// </summary>
        /// <returns />
        /// <remarks>As the Assembly.Location property sometimes gives you funny
        /// results when using Test harnesses (where assemblies run from a temporary 
        /// folder), we will use CodeBase which gives you the path in URI format, 
        /// then UriBuild.UnescapeDataString removes the File:// at the beginning, 
        /// and GetDirectoryName changes it to the normal windows format.
        /// 
        /// Ref:
        ///     http://stackoverflow.com/users/1078/john-sibly
        ///     http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
        /// </remarks>
        public static String GetExecutingDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            return directoryPath;
        }
    }
}