using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Application;

namespace Dibware.Template.Core.Application.Services
{
    /// <summary>
    /// Represents the service used for interacting with TermAndCondition data
    /// </summary>
    public class TermAndConditionService : ITermAndConditionService
    {
        #region Decalarations

        private ITermAndConditionRepository _termAndConditionRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="TermAndConditionService"/> service
        /// </summary>
        /// <param name="termAndConditionRepository">
        /// An instance of an object that implements <see cref="ITermAndConditionRepository"/> repository
        /// </param>
        public TermAndConditionService(ITermAndConditionRepository termAndConditionRepository)
        {
            _termAndConditionRepository = termAndConditionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the current terms and condition entry
        /// </summary>
        /// <returns></returns>
        public TermAndCondition GetCurrent()
        {
            var result = _termAndConditionRepository.GetCurrent();
            return result;
        }

        #endregion
    }
}