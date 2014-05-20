using System;
using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Helpers.Validation;

namespace Dibware.Template.Presentation.Web.Modules.ApplicationState
{
    /// <summary>
    /// Provides application status data
    /// </summary>
    public class MvcApplicationStatusProvider : IApplicationStatusProvider
    {
        #region Constructors
        
        /// <summary>
        /// Creates a new instance of the 
        /// </summary>
        /// <param name="configuration"></param>
        public MvcApplicationStatusProvider(
            IApplicationConfiguration configuration,
            IStatusRepository statusRepository)
        {
            // Validate arguments
            Guard.ArgumentIsNotNull(configuration, "configuration");
            Guard.ArgumentIsNotNull(statusRepository, "statusRepository");

            // Set properties
            ApplicationConfiguration = configuration;
            StatusRepository = statusRepository;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a reference to the ApplicationConfiguration
        /// </summary>
        protected IApplicationConfiguration ApplicationConfiguration { get; private set; }

        /// <summary>
        /// Gets a reference to the StatusRepository
        /// </summary>
        protected IStatusRepository StatusRepository { get; private set; }

        #endregion

        #region IApplicationStatusProvider Members

        /// <summary>
        /// Gets the current state of the application
        /// </summary>
        /// <returns></returns>
        public Status GetCurrentState()
        {
            var defaultStatusID = ApplicationConfiguration.DefaultApplicationStatusId;
            var result = StatusRepository.GetForId(defaultStatusID);
            return result;
        }
        
        #endregion
    }
}