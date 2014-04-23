using Dibware.Template.Core.Domain.Entities.Base;
using System;

namespace Dibware.Template.Core.Domain.Entities.Security
{
    /// <summary>
    /// Represents a rule for password strength
    /// </summary>
    public class PasswordStrengthRule : BaseIdEntity
    {
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the regular expression
        /// </summary>
        public String RegularExpression { get; set; }
    }
}