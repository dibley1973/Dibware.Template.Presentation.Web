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
                    if (!CheckPasswordComplexity(Membership.Provider, model.Password, ModelState, LookupService))
                    {
                        ModelState.AddModelError(DictionaryKeys.Password, ValidationMessages.PasswordNotMetRequiredComplexity);
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
                        String returnLink = Url.Action(
                            ViewNames.ConfirmAccount, 
                            ControllerNames.Account, 
                            new { confirmationToken = confirmationToken });

                        try
                        {
                            //WebMail.SmtpServer
                            WebMail.Send(
                                to: model.EmailAddress,
                                from: "dibley1973@sky.com",
                                subject: "Your confirmation token",
                                body: ("Your confirmation token is: " +
                                    confirmationToken +
                                    " click here: " +
                                    returnLink)

                            );
                        }
                        catch (System.Net.Mail.SmtpException smtpEx)
                        {
                            throw smtpEx;
                        }

                        // Redirect to the confirmation token entry page
                        return RedirectToAction(ViewNames.ConfirmAccount, ControllerNames.Account);
                    }
                    else
                    {
                        // Just log the user in
                        WebSecurity.Login(model.UserName, model.Password);

                        // Redirect to the home page
                        return RedirectToAction(ViewNames.Index, ControllerNames.Home);
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
        public static Boolean CheckPasswordComplexity(MembershipProvider membershipProvider,
            String password, ModelStateDictionary modelState, ILookupService lookupService)
        {
            var initialPasswordErrorCount =
                ((modelState[DictionaryKeys.Password].Errors != null)
                ? modelState[DictionaryKeys.Password].Errors.Count
                : 0);

            // Check for an empty string, as they should fail
            if (string.IsNullOrEmpty(password))
            {
                modelState.AddModelError(DictionaryKeys.Password, ValidationMessages.PasswordEmpty);
            }

            // Check the minumum length meets requirements
            if (membershipProvider.MinRequiredPasswordLength > 0 && password.Length < membershipProvider.MinRequiredPasswordLength)
            {
                modelState.AddModelError(DictionaryKeys.Password, ValidationMessages.PasswordToShort);
            }

            // Check count of non-alpha-numeric characters meets requirements
            CheckPasswordNonAlphaNumericCount(
                membershipProvider.MinRequiredNonAlphanumericCharacters,
                password,
                modelState
            );

            // Check password strength regular expression meets requirements
            CheckPasswordStrength(
                membershipProvider.PasswordStrengthRegularExpression,
                password,
                modelState,
                lookupService);

            // Check that no more errors have been added
            var currentPasswordErrorCount = modelState[DictionaryKeys.Password].Errors.Count;
            var noErrorsEncountered =
                (initialPasswordErrorCount == currentPasswordErrorCount);

            // return the state of that check
            return noErrorsEncountered;
        }

        /// <summary>
        /// Checks the password non alpha numeric count.
        /// </summary>
        /// <param name="minRequiredNonAlphanumericCharacters">The minimum required non alphanumeric characters.</param>
        /// <param name="password">The password.</param>
        /// <param name="modelState">State of the model.</param>
        public static void CheckPasswordNonAlphaNumericCount(
            Int32 minRequiredNonAlphanumericCharacters,
            String password,
            ModelStateDictionary modelState)
        {
            int nonAlphaNumericCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password, i))
                {
                    nonAlphaNumericCount++;
                }
            }
            if (nonAlphaNumericCount < minRequiredNonAlphanumericCharacters)
            {
                modelState.AddModelError(DictionaryKeys.Password,
                    ValidationMessages.PasswordMinNonAlphaNumericNotMet);
            }
        }

        /// <summary>
        /// Checks the password strength.
        /// </summary>
        /// <param name="passwordStrengthRegularExpression">The password strength regular expression.</param>
        /// <param name="password">The password.</param>
        /// <param name="modelState">State of the model.</param>
        /// <param name="lookupService">The lookup service.</param>
        public static void CheckPasswordStrength(
            String passwordStrengthRegularExpression,
            String password,
            ModelStateDictionary modelState,
            ILookupService lookupService)
        {
            // Check password strength regular expression meets requirements
            if (!string.IsNullOrEmpty(passwordStrengthRegularExpression) &&
                !Regex.IsMatch(password, passwordStrengthRegularExpression))
            {
                // Get all of the rules...
                var passwordRules = lookupService.FindAll<PasswordStrengthRule>();

                //... check each one against the password...
                foreach (var passwordRule in passwordRules)
                {
                    var isMatch = Regex.IsMatch(password, passwordRule.RegularExpression);
                    if (!isMatch)
                    {
                        //...and report any rule failures
                        modelState.AddModelError(DictionaryKeys.Password, passwordRule.Description);
                    }
                }
            }
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
                return RedirectToAction(ViewNames.Index, ControllerNames.Home);
            }
        }

        #endregion
    }
}