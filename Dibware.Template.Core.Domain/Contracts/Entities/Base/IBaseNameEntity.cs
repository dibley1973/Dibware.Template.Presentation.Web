using System;

namespace Dibware.Template.Core.Domain.Contracts.Entities.Base
{
    public interface IBaseNameEntity : IBaseEntity
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