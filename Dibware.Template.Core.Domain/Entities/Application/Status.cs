using Dibware.Template.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Domain.Entities.Application
{
    /// <summary>
    /// Represents the state of the system
    /// </summary>
    public class Status : BaseIdEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public Int32 State { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public String Message { get; set; }

        #endregion
    }
}
