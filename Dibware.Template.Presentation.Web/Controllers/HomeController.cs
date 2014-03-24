using Dibware.Template.Presentation.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Resources;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Actions

        //
        // GET: /About/
        //No authorisation, anyone can view this.
        //[WebsiteAuthoriz(UserRole.All)]
        [HttpGet]
        public ActionResult About()
        {
            var model = new AboutViewModel();
            return View(ViewNames.About, model);
        }

        //
        // GET: /Home/
        //No authorisation, anyone can view this.
        //[WebsiteAuthoriz(UserRole.All)]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(ViewNames.Index, model);
        }

        #endregion
    }
}