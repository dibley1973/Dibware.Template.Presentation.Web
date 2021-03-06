﻿using Dibware.Template.Presentation.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dibware.Template.Presentation.Web.Models.Account
{
    public class ConfirmAccountFailureViewModel : BaseViewModel
    {
        [Display(Name = "User name")]
        public String UserName { get; set; }
    }
}