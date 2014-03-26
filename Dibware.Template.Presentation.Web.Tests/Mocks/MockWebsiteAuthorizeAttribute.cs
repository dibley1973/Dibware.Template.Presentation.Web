using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Resources;
using System.Web;

namespace Dibware.Template.Presentation.Web.Tests.Mocks
{
    /// <summary>
    /// This class is just to allow unit tests to cover 
    /// methods that are in protected scope, but would 
    /// otherwise be awkward to test.
    /// </summary>
    public class MockWebsiteAuthorizeAttribute : WebsiteAuthorizeAttribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebsiteAuthorizeAttribute" /> class.
        /// </summary>
        /// <param name="allowedRole">The allowed role.</param>
        public MockWebsiteAuthorizeAttribute(UserRole allowedRole)
            : base(allowedRole) { }

        #endregion

        #region Methods

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        public new bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        #endregion
    }
}