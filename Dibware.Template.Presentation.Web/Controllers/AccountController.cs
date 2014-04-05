using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Account;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Resources;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Security.Policy;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Reference

        // http://stackoverflow.com/questions/669175/unit-testing-asp-net-mvc-authorize-attribute-to-verify-redirect-to-login-page

        #endregion


        #region Actions

        //
        // GET: /Account/
        [WebsiteAuthorize(UserRole.AllAuthorised)]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(ViewNames.Index, model);
        }


        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel();
            ViewBag.ReturnUrl = returnUrl;
            return View(model); ;
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        #endregion

        #region Helper Methods

        private ActionResult RedirectToLocal(String returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}