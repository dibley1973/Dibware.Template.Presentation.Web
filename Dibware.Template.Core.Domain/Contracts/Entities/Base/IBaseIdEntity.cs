using System;

namespace Dibware.Template.Core.Domain.Contracts.Entities.Base
{
    public interface IBaseIdEntity : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Int32 Id { get; set; }
    }
}