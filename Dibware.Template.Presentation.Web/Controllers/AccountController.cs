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
    /// <summary>
    /// 
    /// </summary>
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
        // GET: /Account/ChangePassword
        [HttpGet]
        [WebsiteAuthorize(UserRole.AllAuthorised)]
        public ActionResult ChangePassword()
        {
            // Check if user is NOT logged in
            if (!WebSecurity.IsAuthenticated)
            {
                // Throw them out to the login screen
                return View(ViewNames.Login, new LoginViewModel());
            }

            var model = new ChangePasswordViewModel();
            return View(ViewNames.ChangePassword, model);
        }

        //
        // GET: /Account/ChangePassword
        [HttpPost]
        [WebsiteAuthorize(UserRole.AllAuthorised)]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            // Check if user is NOT logged in
            if (!WebSecurity.IsAuthenticated)
            {
                // Throw them out to the login screen
                return View(ViewNames.Login, new LoginViewModel());
            }

            // Check if the model is valid...
            var modelIsValid = ModelState.IsValid;
            if (!modelIsValid)
            {
                // ... it isn't so throw the user back out to form
                return View(ViewNames.ChangePassword, model);
            }

            String username = HttpContext.User.Identity.Name;
            String currentPassword = model.CurrentPassword;
            String newPassword = model.NewPassword;

            // Check the complexity of the new password meets the requirement of 
            // the membership provider
            if (!CheckPasswordComplexity(Membership.Provider, newPassword, ModelState, DictionaryKeys.NewPassword, LookupService))
            {
                ModelState.AddModelError(DictionaryKeys.NewPassword, ValidationMessages.PasswordNotMetRequiredComplexity);
                return View(model);
            }

            // Try to change the password and warn the user of any issues
            try
            {
                WebSecurity.ChangePassword(username, currentPassword, newPassword);
                WebSecurity.Logout();
                return View(ViewNames.ChangePasswordConfirmed, new ChangePasswordConfirmedViewModel());
            }
            catch (ValidationException validationEx)
            {
                // Report Validation Exceptions as model errors
                ModelState.AddModelError(String.Empty, validationEx.Message);

                // ... throw the user back out
                return View(ViewNames.ChangePassword, model);
            }
        }

        //
        // GET: /Account/ConfirmAccountAwaitEmail
        [HttpGet]
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

        //
        // GET: /Account/ConfirmAccountSuccess
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmAccountSuccess()
        {
            var model = new ConfirmAccountSuccessViewModel();
            return View(ViewNames.ConfirmAccountSuccess, model);
        }

        //
        // GET: /Account/ConfirmAccountFailure
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmAccountFailure()
        {
            var model = new ConfirmAccountFailureViewModel();
            return View(ViewNames.ConfirmAccountFailure, model);
        }

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
            // check if user is already logged in
            if (WebSecurity.IsAuthenticated)
            {
                return RedirectToLocalOrDefault(returnUrl);
            }

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
            // check if user is already logged in
            if (WebSecurity.IsAuthenticated)
            {
                return RedirectToLocalOrDefault(returnUrl);
            }

            // Check if the model is valid...
            var modelIsValid = ModelState.IsValid;
            if (!modelIsValid)
            {
                // ... it isn't so throw the user back out
                return View(ViewNames.Login, model);
            }

            try
            {
                String username = model.UserName;
                String password = model.Password;

                // Check if the user exists in the system
                Boolean userExists = WebSecurity.UserExists(username);
                if (!userExists)
                {
                    // ... they don't so add an error and kick the user back to the login page
                    ModelState.AddModelError(FieldNames.Username, ValidationMessages.UsernameNotRecognised);
                    return View(ViewNames.Login, model);
                }

                // Check if the user has a confirmed account...
                Boolean isconfirmed = WebSecurity.IsConfirmed(username);
                if (!isconfirmed)
                {
                    // ... we are not logged in, so add an error and kick the user back
                    ModelState.AddModelError(String.Empty, ValidationMessages.EmailNotConfirmed);
                    return View(ViewNames.Login, model);
                }

                // Ref:
                //  http://www.thecodingguys.net/reference/asp/websecurity-login
                // Check if the user has made too many failed login attempts (x) 
                // with the wrong password and their then their account is locked 
                // out for (y) minutes. 
                // Note:
                //  The time must be UTC, as that is how it is stored in the database!
                Int32 maximumPasswordFailuresSinceLastLogin = Int32.Parse(ConfigurationManager.AppSettings[ConfigurationKeys.MaximumPasswordFailuresSinceLastLogin]);
                Int32 accountLockoutTimeInMinutes = Int32.Parse(ConfigurationManager.AppSettings[ConfigurationKeys.AccountLockoutTimeInMinutes]);
                if (WebSecurity.GetPasswordFailuresSinceLastSuccess(username) > maximumPasswordFailuresSinceLastLogin &&
                    WebSecurity.GetLastPasswordFailureDate(username).AddMinutes(accountLockoutTimeInMinutes) > DateTime.UtcNow)
                {
                    String errorMessage = String.Format(
                        ValidationMessages.AccountLockedOut,
                        accountLockoutTimeInMinutes,
                        maximumPasswordFailuresSinceLastLogin
                        );
                    ModelState.AddModelError(String.Empty, errorMessage);
                    return View(ViewNames.Login, model);
                }

                // Check is the user is logged in...
                var isLoggedIn = WebSecurity.Login(username,
                    password, persistCookie: model.RememberMe);
                if (!isLoggedIn)
                {
                    // ... we are not logged in, so add an error and kick the user back
                    ModelState.AddModelError(String.Empty, ValidationMessages.PasswordIncorrect);
                    return View(ViewNames.Login, model);
                }

                // We have got this far so return the user to the passed URL
                return RedirectToLocalOrDefault(returnUrl);
            }
            catch (ValidationException validationEx)
            {
                // Report Validation Exceptions as model errors
                ModelState.AddModelError(String.Empty, validationEx.Message);

                // ... throw the user back out
                return View(ViewNames.Login, model);
            }
        }

        //
        // GET: /Account/Logout
        [HttpGet]
        [WebsiteAuthorize(UserRole.AllAuthorised)]
        public ActionResult Logout()
        {
            // check if user is already logged in
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToLocalOrDefault(null);
            }
            var model = new LogoutViewModel();
            model.UserName = this.User.Name; // System.Web.Http.H HttpContext.Current.User.

            WebSecurity.RequireAuthenticatedUser();
            WebSecurity.Logout();
            return View(ViewNames.Logout, model);
        }

        //
        // GET: /Account/RecoverPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
            var model = new RecoverPassword();
            return View(model);
        }

        //
        // POST: /Account/RecoverPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPassword(RecoverPassword model)
        {
            // Check if the model is valid...
            var modelIsValid = ModelState.IsValid;
            if (!modelIsValid)
            {
                // ... it isn't so throw the user back out
                return View(ViewNames.RecoverPassword, model);
            }


            return View(ViewNames.RecoverPassword, model);
        }



        //
        // GET: /Account/Register
        [HttpGet]
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
                    if (!CheckPasswordComplexity(Membership.Provider, model.Password, ModelState, DictionaryKeys.Password, LookupService))
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
                        return RedirectToHome();
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
        /// <param name="modelState">State of the model.</param>
        /// <param name="modelStatePasswordDictionaryKey">The model state password dictionary key.</param>
        /// <param name="lookupService">The lookup service.</param>
        /// <returns>
        /// true if the password meets the req. complexity
        /// </returns>
        public static Boolean CheckPasswordComplexity(MembershipProvider membershipProvider,
            String password,
            ModelStateDictionary modelState,
            String modelStatePasswordDictionaryKey,
            ILookupService lookupService)
        {
            var initialPasswordErrorCount =
                ((modelState[modelStatePasswordDictionaryKey].Errors != null)
                ? modelState[modelStatePasswordDictionaryKey].Errors.Count
                : 0);

            // Check for an empty string, as they should fail
            if (string.IsNullOrEmpty(password))
            {
                modelState.AddModelError(modelStatePasswordDictionaryKey, ValidationMessages.PasswordEmpty);
            }

            // Check the minumum length meets requirements
            if (membershipProvider.MinRequiredPasswordLength > 0 && password.Length < membershipProvider.MinRequiredPasswordLength)
            {
                modelState.AddModelError(modelStatePasswordDictionaryKey, ValidationMessages.PasswordToShort);
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
                modelStatePasswordDictionaryKey,
                lookupService);

            // Check that no more errors have been added
            var currentPasswordErrorCount = modelState[modelStatePasswordDictionaryKey].Errors.Count;
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
        /// <param name="modelStatePasswordDictionaryKey">The model state password dictionary key.</param>
        /// <param name="lookupService">The lookup service.</param>
        public static void CheckPasswordStrength(
            String passwordStrengthRegularExpression,
            String password,
            ModelStateDictionary modelState,
            String modelStatePasswordDictionaryKey,
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
                        modelState.AddModelError(modelStatePasswordDictionaryKey, passwordRule.Description);
                    }
                }
            }
        }

        /// <summary>
        /// Redirects to the home page.
        /// </summary>
        /// <returns></returns>
        private ActionResult RedirectToHome()
        {
            return RedirectToAction(ActionMethods.Index, ControllerNames.Home);
        }

        /// <summary>
        /// Redirects to a local url, or default (Home/Index) if url is null.
        /// </summary>
        /// <param name="url">The URL to redirect to or null.</param>
        /// <returns></returns>
        private ActionResult RedirectToLocalOrDefault(String url)
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