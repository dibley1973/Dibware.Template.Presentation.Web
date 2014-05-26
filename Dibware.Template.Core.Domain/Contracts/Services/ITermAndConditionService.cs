using Dibware.Template.Core.Domain.Entities.Application;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    public interface ITermAndConditionService
    {
        /// <summary>
        /// Gets the current terms and conditions.
        /// </summary>
        /// <returns></returns>
        TermAndCondition GetCurrent();
    }
}