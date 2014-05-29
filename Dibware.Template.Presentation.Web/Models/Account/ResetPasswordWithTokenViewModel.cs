using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class ResetPasswordWithTokenViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Password Reset Token")]
        public String PasswordResetToken { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public String NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation of new password do not match.")]
        public String ConfirmNewPassword { get; set; }
    }
}