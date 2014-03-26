using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dibware.Helpers.System;
using Dibware.Helpers.Validation;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Resources;
using Ninject;

namespace Dibware.Template.Presentation.Web.Modules.Authentication
{
    public class WebsiteAuthorizeAttribute : AuthorizeAttribute
    {
        #region Private Members

        private UserRole _allowedRole = UserRole.None;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the app configuration.
        /// </summary>
        /// <value>
        /// The app configuration.
        /// </value>
        [Inject]
        public IApplicationConfiguration AppConfiguration { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="allowedRole">The allowed role.</param>
        public WebsiteAuthorizeAttribute(UserRole allowedRole)
        {
            _allowedRole = allowedRole;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a process requests authorization.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context, which encapsulates information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="filterContext"/> parameter is null.
        /// </exception>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Guard.ArgumentIsNotNull(filterContext, "filterContext");

            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentNullException">httpContext</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Guard.ArgumentIsNotNull(httpContext, "httpContext");

            // If user is not authenticates, return false regardless!
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            // see if the user is in any of the mapped roles.
            var result = EnumHelper.GetAllSelectedItems<UserRole>(_allowedRole)
                .Any(role => httpContext.User.IsInRole(GetMappedRole(role)));


            //foreach (var role in EnumHelper.GetAllSelectedItems<UserRole>(this._allowedRole))
            //{
            //    // ... and see if our current user is in the mapped role.
            //    if (httpContext.User.IsInRole(this.GetMappedRole(role)))
            //    {
            //        result = true;
            //        break; // For performance.
            //    }
            //}

            return result;
        }

        /// <summary>
        /// Gets the mapped role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        private static String GetMappedRole(UserRole role)
        {
            return EnumHelper.GetName<UserRole>(role);
        }

        #endregion
    }
}