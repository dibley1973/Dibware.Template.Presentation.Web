using System;

namespace Dibware.Template.Core.Domain.Contracts.Entities.Base
{
    public interface IBaseEntity : IEntityClonable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        String Name { get; set; }
    }
}