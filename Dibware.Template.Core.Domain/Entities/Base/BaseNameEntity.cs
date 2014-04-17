using System;

namespace Dibware.Template.Core.Domain.Entities.Base
{
    /// <summary>
    /// This is the base that all named entities should inherit from.
    /// </summary>
    public abstract class BaseNameEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }
    }
}