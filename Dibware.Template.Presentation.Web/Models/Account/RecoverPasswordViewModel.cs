using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class RecoverPasswordViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public String Username { get; set; }
    }
}