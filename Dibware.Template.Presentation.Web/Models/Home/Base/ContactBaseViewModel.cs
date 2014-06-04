using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Home.Base
{
    public class ContactBaseViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}