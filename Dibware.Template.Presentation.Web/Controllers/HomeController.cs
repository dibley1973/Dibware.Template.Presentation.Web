using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class HomeController : BaseControllerWithDataLookup
    {
        #region Private Members

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
        // GET: /Contact/
        // No authorisation, anyone can view this.
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            var model = new ContactViewModel();
            return View(ViewNames.Contact, model);
        }

        //
        // POST: /Contact/
        // No authorisation, anyone can view this.
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send contact email to new registerant
                EmailHelper.SendContactEmail(
                    model.Name,
                    model.EmailAddress,
                    model.Enquiry);

                var sentModel = new ContactEmailSentViewModel();
                return View(ViewNames.ContactEmailSent, sentModel);
            }
            // If we got this far, something failed, redisplay form
            return View(ViewNames.Contact, model);
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