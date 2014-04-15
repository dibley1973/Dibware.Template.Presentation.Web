using Dibware.Template.Core.Application.Exceptions;
using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Application.Base
{
    public class DataService<TEntity> : IDataService<TEntity> where TEntity : class
    {
        #region Private members

        private IRepository<TEntity> _repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
        /// </summary>
        /// <param name="departmentRepository">The department repository.</param>
        public DataService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        #endregion

        #region IService<TEntity> Members

        /// <summary>
        /// Finds the entity specified by an ID
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns></returns>
        public virtual TEntity Find(Int32 id)
        {
            // Get entity from repository
            var entity = this._repository.GetForId(id);

            return entity;
        }

        /// <summary>
        /// Finds the entity specified by a GUID
        /// </summary>
        /// <param name="guid">The GUID of the entity</param>
        /// <returns></returns>
        public virtual TEntity Find(Guid guid)
        {
            // Get entity from repository
            var entity = this._repository.GetForGuid(guid);

            return entity;
        }

        /// <summary>
        /// Finds the entity specified by a key
        /// </summary>
        /// <param name="key">The key of the entity</param>
        /// <returns></returns>
        public virtual TEntity Find(String key)
        {
            // Get entity from repository
            var entity = this._repository.GetForKey(key);

            return entity;
        }

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<TEntity> FindAll()
        {
            // Get entities from repository
            var entities = this._repository.GetAll();

            return entities;
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public virtual TEntity AddNew(TEntity entity)
        {
            // Perform operations on repository
            try
            {
                // Create new entity
                entity = this._repository.Create(entity);

                // Save the repository
                this._repository.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ServiceException"></exception>
        public virtual void Update(TEntity entity)
        {
            // Perform operations on repository
            try
            {
                // Update the entity
                this._repository.Update(entity);

                // Save the repository
                this._repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an existing entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            // Perform operations on repository
            try
            {
                this._repository.Delete(entity);
                this._repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        #endregion
    }
}
