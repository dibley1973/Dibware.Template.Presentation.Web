
namespace Dibware.Template.Core.Domain.Contracts.UnitOfWork
{
    /// <summary>
    /// Extends the IUnitOfWork contract. Does not provides any extra functionality 
    /// but can be used to define the anticpated scope of the life expectancy 
    /// of a UnitOfWork for mapping when using DI frameworks like ninject.
    /// </summary>
    public interface IUnitOfWorkInRequestScope : IUnitOfWork
    {
    }
}
