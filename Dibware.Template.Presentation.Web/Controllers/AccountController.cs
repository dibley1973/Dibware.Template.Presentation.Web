using Dibware.Extensions.System.Collections;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Models.Account;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Resources;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class AccountController : BaseControllerWithDataLookup
    {
        #region Reference

        // http://stackoverflow.com/questions/669175/unit-testing-asp-net-mvc-authorize-attribute-to-verify-redirect-to-login-page

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="lookupService">The lookup service.</param>
        public AccountController(ILookupService lookupService)
            : base(lookupService) { }

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
        public ActionResult ExternalLoginsList(String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(String returnUrl)
        {
            var model = new LoginViewModel();
            ViewBag.ReturnUrl = returnUrl;
            return View(ViewNames.Login, model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, String returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(ViewNames.Login, model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(ViewNames.Register, model);
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {

                    // Check the password complexity meets the requirement of 
                    // the membership provider
                    if (!CheckPasswordComplexity(Membership.Provider, model.Password))
                    {
                        ModelState.AddModelError("Password", ValidationMessages.PasswordNotMetRequiredComplexity);

                        var passwordRules = LookupService.FindAll<PasswordStrengthRule>();
                        var descriptions = passwordRules.Select(r => r.Description);

                        Action<String> action = s => ModelState.AddModelError("Password", s);
                        descriptions.ForEach(action);

                        return View(model);
                    }

                    // Get the flag for is a confirmation token is required from the web.config.
                    var requireConfirmationToken =
                        Convert.ToBoolean(
                            ConfigurationManager.AppSettings[ConfigurationKeys.RequireConfirmationToken]);

                    var propertyValues = new Dictionary<String, Object>();
                    propertyValues.Add(DictionaryKeys.EmailAddress, model.EmailAddress);

                    // try and create the user's account
                    //String confirmationToken = WebSecurity.CreateUserAndAccount(
                    //    model.UserName,
                    //    model.Password,
                    //    propertyValues: propertyValues,
                    //    requireConfirmationToken: requireConfirmationToken);

                    // really odd. If you do it the way of above, then the 
                    // property values get nested!
                    String confirmationToken = WebSecurity.CreateUserAndAccount(
                        model.UserName,
                        model.Password,
                        propertyValues: new { EmailAddress = model.EmailAddress },
                        requireConfirmationToken: requireConfirmationToken);

                    if (requireConfirmationToken)
                    {
                        // send the user an email with the token.
                        // TODO: create a nice email body and the correct link
                        String returnLink = Url.Action("ConfirmAccount", "Account", new { confirmationToken = confirmationToken });

                        WebMail.Send(
                            to: model.EmailAddress,
                            subject: "Your confirmation token",
                            body: "Your confirmation token is: " +
                                confirmationToken +
                                " click here: " +
                                returnLink
                        );

                        // Redirect to the confirmation token entry page
                        return RedirectToAction("ConfirmAccount", "Account");
                    }
                    else
                    {
                        // Just log the user in
                        WebSecurity.Login(model.UserName, model.Password);

                        // Redirect to the home page
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", MembershipHelper.ConvertErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ViewNames.Register, model);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Checks password complexity requirements for the given membership provider
        /// </summary>
        /// <param name="membershipProvider">membership provider</param>
        /// <param name="password">password to check</param>
        /// <returns>true if the password meets the req. complexity</returns>
        static public Boolean CheckPasswordComplexity(MembershipProvider membershipProvider, string password)
        {
            // Check for an empty string, as they should fail
            if (string.IsNullOrEmpty(password)) { return false; }

            // Check the minumum length meets requirements
            if (password.Length < membershipProvider.MinRequiredPasswordLength) return false;

            // Check count of non-alpha-numeric characters meets requirements
            int nonAlphaNumericCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password, i))
                {
                    nonAlphaNumericCount++;
                }
            }
            if (nonAlphaNumericCount < membershipProvider.MinRequiredNonAlphanumericCharacters)
            {
                return false;
            }

            // Check password strength regular expression meets requirements
            if (!string.IsNullOrEmpty(membershipProvider.PasswordStrengthRegularExpression) &&
                !Regex.IsMatch(password, membershipProvider.PasswordStrengthRegularExpression))
            {
                return false;
            }

            // Well we got here so all is good!
            return true;
        }

        /// <summary>
        /// Redirects to a local url.
        /// </summary>
        /// <param name="url">The URL to redirect to.</param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(String url)
        {
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}