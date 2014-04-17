using System;

namespace Dibware.Template.Core.Domain.Entities.Base
{
    public class BaseIdNameEntity : BaseNameEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int32 Id { get; set; }
    }
}
