
namespace Dibware.Template.Core.Domain.Contracts.Services
{
    public interface ICloneService
    {
        /// <summary>
        /// Clones the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        T Clone<T>(T instance) where T : class;
    }
}