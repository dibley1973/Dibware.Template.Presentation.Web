using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class RecoverPasswordEmailSentModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the time in minutes from now for the token expiration.
        /// </summary>
        /// <value>
        /// The token expiration in minutes from now.
        /// </value>
        public Int32 TokenExpirationInMinutesFromNow { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Display(Name = "User name")]
        public String UserName { get; set; }
    }
}