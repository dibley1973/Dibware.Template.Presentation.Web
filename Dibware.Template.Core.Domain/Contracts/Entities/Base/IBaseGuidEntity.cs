using System;

namespace Dibware.Template.Core.Domain.Contracts.Entities.Base
{
    public interface IBaseGuidEntity : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        Guid Guid { get; set; }
    }
}