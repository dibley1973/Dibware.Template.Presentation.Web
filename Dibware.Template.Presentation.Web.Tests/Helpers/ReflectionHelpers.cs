using System;
using System.Linq.Expressions;

namespace Dibware.Template.Presentation.Web.Tests.Helpers
{
    public static class ReflectionHelpers
    {
        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TU">The type of the u.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Expression is wrong</exception>
        public static string GetMethodName<T, TU>(Expression<Func<T, TU>> expression)
        {
            var method = expression.Body as MethodCallExpression;
            if (method != null)
            {
                return method.Method.Name;
            }
            throw new ArgumentException("Expression is wrong");
        }
    }
}