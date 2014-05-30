using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Application;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    /// <summary>
    /// Defines the expected members of a TermAndCondition Repository
    /// </summary>
    public interface ITermAndConditionRepository : IRepository<TermAndCondition>
    {
        /// <summary>
        /// Gets the current terms and condition.
        /// </summary>
        /// <returns></returns>
        TermAndCondition GetCurrent();
    }
}