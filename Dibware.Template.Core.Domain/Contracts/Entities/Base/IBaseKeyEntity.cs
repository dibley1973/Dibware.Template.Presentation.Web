using System;

namespace Dibware.Template.Core.Domain.Contracts.Entities.Base
{
    public interface IBaseKeyEntity : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        String Key { get; set; }
    }
}