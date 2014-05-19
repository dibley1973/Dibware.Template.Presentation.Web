using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class RecoverPassword : BaseViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "The email address is not in a valid format")] //TODO: Move this string from here in to a global config
        public String EmailAddress { get; set; }
    }
}