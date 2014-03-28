using Dibware.Template.Presentation.Web.Models.Base;
using System;

namespace Dibware.Template.Presentation.Web.Models.Error
{
    public class ErrorViewModel : BaseViewModel
    {
        public Exception Exception { get; set; }
    }
}