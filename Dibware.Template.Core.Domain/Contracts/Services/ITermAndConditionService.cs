using Dibware.Template.Core.Domain.Entities.Application;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    /// <summary>
    /// Defines the expected members of a TermAndCondition Service
    /// </summary>
    public interface ITermAndConditionService
    {
        /// <summary>
        /// Gets the current terms and conditions.
        /// </summary>
        /// <returns></returns>
        TermAndCondition GetCurrent();
    }
}