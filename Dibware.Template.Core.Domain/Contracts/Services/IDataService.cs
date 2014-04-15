using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dibware.Template.Core.Domain.Contracts.Services
{
    public interface IDataService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finds the entity specified by an ID
        /// </summary>
        /// <param name="id">The ID of the entity</param>
        /// <returns></returns>
        TEntity Find(Int32 id);

        /// <summary>
        /// Finds the entity specified by a GUID
        /// </summary>
        /// <param name="guid">The GUID of the entity</param>
        /// <returns></returns>
        TEntity Find(Guid guid);

        /// <summary>
        /// Finds the entity specified by a key
        /// </summary>
        /// <param name="key">The key of the entity</param>
        /// <returns></returns>
        TEntity Find(String key);

        /// <summary>
        /// Finds all entities
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> FindAll();

        /// <summary>
        /// Adds a new Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity AddNew(TEntity entity);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an existing entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}