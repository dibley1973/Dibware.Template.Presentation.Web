using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class ConfirmAccount : BaseViewModel
    {
        [Display(Name = "User name")]
        public String UserName { get; set; }

        [Display(Name = "Confirmation Token")]
        public String ConfirmationToken { get; set; }
    }
}