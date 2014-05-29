using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class HomeController : BaseControllerWithDataLookup
    {
        #region Declarations

        private ITermAndConditionService _termAndConditionService;

        #endregion

        #region Constructors

        ///// <summary>
        ///// Initializes a new instance of the <see cref="AccountController"/> class.
        ///// </summary>
        ///// <param name="lookupService">The lookup service.</param>
        //public HomeController(ILookupService lookupService)
        //    : base(lookupService) { }

        //TODO: swap constructors when all service code is complete...
        //
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="lookupService">The lookup service.</param>
        public HomeController(ILookupService lookupService,
            ITermAndConditionService termAndConditionService)
            : base(lookupService)
        {
            _termAndConditionService = termAndConditionService;
        }

        #endregion

        #region Actions

        //
        // GET: /About/
        // No authorisation, anyone can view this.
        [HttpGet]
        [AllowAnonymous]
        public ActionResult About()
        {
            var model = new AboutViewModel();
            return View(ViewNames.About, model);
        }

        //
        // GET: /Home/
        // No authorisation, anyone can view this.
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(ViewNames.Index, model);
        }

        //
        // GET: /Status/
        // No authorisation, anyone can view this.
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Status(String message)
        {
            var model = new StatusViewModel
            {
                Message = message
            };
            return View(ViewNames.Status, model);
        }

        //
        // GET: /Terms/
        // No authorisation, anyone can view this.
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Terms()
        {
            var model = new TermsViewModel()
            {
                CurrentTerms = _termAndConditionService.GetCurrent()
            };
            return View(ViewNames.Terms, model);
        }

        #endregion
    }
}