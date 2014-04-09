using Dibware.Template.Core.Domain.Entities.Base;

namespace Dibware.Template.Core.Domain.Entities.Security
{
    /// <summary>
    /// Represents a user of the system
    /// </summary>
    public class User : BaseGuidEntity
    {

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public string UserName { get; set; }
    }
}