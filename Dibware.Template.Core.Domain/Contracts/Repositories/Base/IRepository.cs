using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets for the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        TEntity GetForGuid(Guid guid);

        /// <summary>
        /// Gets for the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TEntity GetForId(Int32 id);

        /// <summary>
        /// Gets for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TEntity GetForKey(String key);

        /// <summary>
        /// Gets for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        TEntity GetForName(String name);

        ICollection<TEntity> GetAll();
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Merge(TEntity persisted, TEntity modified);
        void SaveChanges();
        void DiscardChanges();
    }
}