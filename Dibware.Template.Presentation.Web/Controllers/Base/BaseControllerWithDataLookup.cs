using Dibware.Template.Core.Domain.Contracts.Services;

namespace Dibware.Template.Presentation.Web.Controllers.Base
{
    /// <summary>
    /// This is the controller adds data lookup functionality to the BaseController.
    /// </summary>
    public abstract class BaseControllerWithDataLookup : BaseController
    {
        #region Private Members

        private ILookupService _lookupService;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the lookup service.
        /// </summary>
        /// <value>
        /// The lookup service.
        /// </value>
        protected ILookupService LookupService
        {
            get { return _lookupService; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerWithDataLookup"/> class.
        /// </summary>
        /// <param name="lookupService">The lookup service.</param>
        protected BaseControllerWithDataLookup(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        #endregion
    }
}