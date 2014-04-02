using System;

namespace Dibware.Template.Core.Domain.Entities.Base
{
    public class BaseGuidEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public Guid Guid { get; set; }
    }
}