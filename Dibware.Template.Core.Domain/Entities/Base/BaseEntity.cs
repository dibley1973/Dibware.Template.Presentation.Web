using Dibware.Template.Core.Domain.Contracts.Services;
using System;

namespace Dibware.Template.Core.Domain.Entities.Base
{
    /// <summary>
    /// This is the base that all entities should inherit from.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Clones this instance using the specified service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        public T Clone<T>(ICloneService service) where T : class
        {
            return service.Clone(this as T);
        }
    }
}