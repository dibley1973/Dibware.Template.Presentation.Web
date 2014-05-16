using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class ChangePasswordConfirmedViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public String UserName { get; set; }
    }
}