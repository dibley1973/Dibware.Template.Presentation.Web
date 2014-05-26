using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Presentation.Web.Models.Base;

namespace Dibware.Template.Presentation.Web.Models.Home
{
    public class TermsViewModel : BaseViewModel
    {
        public TermAndCondition CurrentTerms { get; set; }
    }
}