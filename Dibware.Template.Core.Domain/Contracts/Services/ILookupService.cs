using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    /// <summary>
    /// Defines the expected members for a data look-up service
    /// </summary>
    public interface ILookupService
    {
        ICollection<TEntity> FindAll<TEntity>() where TEntity : class;
        TEntity FindById<TEntity>(int id) where TEntity : class;
        TEntity FindByKey<TEntity>(string key) where TEntity : class;
    }
}