using Dibware.Template.Core.Domain.Contracts.Services;

namespace Dibware.Template.Core.Domain.Contracts.Entities
{
    public interface IEntityClonable
    {
        T Clone<T>(ICloneService service) where T : class;
    }
}