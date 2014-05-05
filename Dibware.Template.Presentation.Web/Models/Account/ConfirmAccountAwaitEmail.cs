using Dibware.Template.Presentation.Web.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class ConfirmAccountAwaitEmail : BaseViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}