using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Resources;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class HomeController : BaseControllerWithDataLookup
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="lookupService">The lookup service.</param>
        public HomeController(ILookupService lookupService)
            : base(lookupService) { }

        #endregion

        #region Actions

        //
        // GET: /About/
        // No authorisation, anyone can view this.
        //[WebsiteAuthorize(UserRole.All)]
        [HttpGet]
        public ActionResult About()
        {
            var model = new AboutViewModel();
            return View(ViewNames.About, model);
        }

        //
        // GET: /Home/
        // No authorisation, anyone can view this.
        ////[WebsiteAuthorize(UserRole.All)]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(ViewNames.Index, model);
        }

        //
        // GET: /Terms/
        // No authorisation, anyone can view this.
        ////[WebsiteAuthorize(UserRole.All)]
        [HttpGet]
        public ActionResult Terms()
        {
            var model = new TermsViewModel();
            return View(ViewNames.Terms, model);
        }

        #endregion
    }
}