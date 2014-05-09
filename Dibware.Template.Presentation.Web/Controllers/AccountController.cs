using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Core.Domain.Exceptions;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Models.Account;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Resources;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Configuration;
using System.Security.Policy;
using System.Text.RegularExpressions;
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
        // GET: /Account/ConfirmAccountAwaitEmail
        [AllowAnonymous]
        public ActionResult ConfirmAccountCheckEmail(String username)
        {
            // await for email...
            var model = new ConfirmAccountCheckEmailViewModel()
            {
                UserName = username
            };
            return View(ViewNames.ConfirmAccountCheckEmail, model);
        }

        ////
        //// GET: /Account/ConfirmAccount
        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult ConfirmAccount()
        //{
        //    var model = new ConfirmAccountViewModel();
        //    return View(ViewNames.ConfirmAccount, model);
        //}

        //
        // GET: /Account/ConfirmAccount/confirmationtoken=
        [AllowAnonymous]
        public ActionResult ConfirmAccount(String confirmationToken)
        {
            if (WebSecurity.ConfirmAccount(confirmationToken))
            {
                return RedirectToAction(ActionMethods.ConfirmAccountSuccess);
            }
            return RedirectToAction(ActionMethods.ConfirmAccountFailure);
        }

        //
        // GET: /Account/ConfirmAccount/username= &confirmationtoken=
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmAccount(String username, String confirmationToken)
        {
            try
            {
                if (WebSecurity.ConfirmAccount(username, confirmationToken))
                {
                    return RedirectToAction(ActionMethods.ConfirmAccountSuccess);
                }
                return RedirectToAction(ActionMethods.ConfirmAccountFailure);
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("", vEx.Message);
                return RedirectToAction(ActionMethods.ConfirmAccountFailure);
            }
        }

        //
        // POST: /Account/ConfirmAccount/ConfirmAccountModel
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ConfirmAccount(ConfirmAccountViewModel model)
        {
            try
            {
                if (WebSecurity.ConfirmAccount(model.UserName, model.ConfirmationToken))
                {
                    return RedirectToAction(ActionMethods.ConfirmAccountSuccess);
                }
                return RedirectToAction(ActionMethods.ConfirmAccountFailure);
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("", vEx.Message);
                return View(ViewNames.ConfirmAccount, model);
            }
        }

        [AllowAnonymous]
        public ActionResult ConfirmAccountSuccess()
        {
            return View(ViewNames.ConfirmAccountSuccess);
        }

        [AllowAnonymous]
        public ActionResult ConfirmAccountFailure()
        {
            return View(ViewNames.ConfirmAccountFailure);
        }

        //{
        //    if (String.IsNullOrEmpty(confirmationToken) || (!Regex.IsMatch(confirmationToken,
        //            @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}")))
        //    {
        //        TempData["tempMessage"] =
        //            "The user account is not valid. Please try clicking the link in your email again."
        //        return View();
        //    }
        //    else
        //    {
        //        var accountconfirmed = WebSecurity.ConfirmAccount(username, confirmationToken);
        //        WebSecurity.L

        //    MembershipUser user = Membership.GetUser(new Guid(ID));

        //    if (!user.IsApproved)
        //    {
        //        user.IsApproved = true;
        //        Membership.UpdateUser(user);
        //        FormsService.SignIn(user.UserName, false);
        //        return RedirectToAction("welcome");
        //    }
        //    else
        //    {
        //        FormsService.SignOut();
        //        TempData["tempMessage"] = "You have already confirmed your email address... please log in.";
        //        return RedirectToAction("LogOn");
        //    }
        //}

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
            // Check if the model is valid...
            var modelIsValid = ModelState.IsValid;
            if (!modelIsValid)
            {
                // ... it isn't so throw the user back out
                return View(ViewNames.Login, model);
            }

            try
            {
                // Check if the user has a confirmed account...
                Boolean isconfirmed = WebSecurity.IsConfirmed(model.UserName);
                if (!isconfirmed)
                {
                    // ... we are not logged in, so add an error and kick the user back
                    ModelState.AddModelError(String.Empty, ValidationMessages.EmailNotConfirmed);
                    return View(ViewNames.Login, model);
                }

                // Check is the user is logged in...
                var isLoggedIn = WebSecurity.Login(model.UserName,
                    model.Password, persistCookie: model.RememberMe);
                if (!isLoggedIn)
                {
                    // ... we are not logged in, so add an error and kick the user back
                    ModelState.AddModelError(String.Empty, ValidationMessages.UsernameOrPasswordIncorrect);
                    return View(ViewNames.Login, model);
                }

                // We have got this far so return the user to the passed URL
                return RedirectToLocal(returnUrl);
            }
            catch (ValidationException validationEx)
            {
                // Report Validation Exceptions as model errors
                ModelState.AddModelError("", validationEx.Message);

                // ... throw the user back out
                return View(ViewNames.Login, model);
            }
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

                    //// Set extended properties
                    //var propertyValues = new Dictionary<String, Object>
                    //{
                    //    { DictionaryKeys.EmailAddress, model.EmailAddress }
                    //};

                    //// Try and create the user's account
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
                        // Create the return relative url
                        var relativeUrl = Url.Action(
                            ViewNames.ConfirmAccount,
                            ControllerNames.Account,
                            new
                            {
                                username = model.UserName,
                                confirmationToken = confirmationToken
                            });

                        // Send confirmation email to new registerant
                        EmailHelper.SendConfirmationEmail(
                            model.EmailAddress,
                            model.UserName,
                            confirmationToken,
                            relativeUrl);

                        // Redirect to the confirmation token entry page
                        return RedirectToAction(ActionMethods.ConfirmAccountCheckEmail, ControllerNames.Account, new { @username = model.UserName });
                    }
                    else
                    {
                        // Just log the user in
                        WebSecurity.Login(model.UserName, model.Password);

                        // Redirect to the home page
                        return RedirectToAction(ActionMethods.Index, ControllerNames.Home);
                    }
                }
                catch (MembershipCreateUserException membEx)
                {
                    ModelState.AddModelError("", MembershipHelper.ConvertErrorCodeToString(membEx.StatusCode));
                }
                catch (ValidationException validationEx)
                {
                    // Report Validation Exceptions as model errors
                    ModelState.AddModelError("", validationEx.Message);
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