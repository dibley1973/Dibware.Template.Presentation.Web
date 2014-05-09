
using System;
using System.Reflection;
namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers
{
    /// <summary>
    /// Helps instanciate objects without a constructor
    /// </summary>
    /// <remarks>
    /// Thanks to "default.kramer" in the following SO post:
    ///     http://stackoverflow.com/questions/1386962/how-to-throw-a-sqlexceptionneed-for-mocking
    /// </remarks>
    public static class ObjectInstanciator
    {
        /// <summary>
        /// Instantiates an instance of the specified Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Instantiate<T>() where T : class
        {
            return System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(T)) as T;
        }

        /// <summary>
        /// Constructs the specified Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constructorIndex">Index of the constructor.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static T Construct<T>(Int32 constructorIndex, params object[] parameters)
        {
            return (T)typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)[constructorIndex].Invoke(parameters);
        }
    }
}
