using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Private Members

        protected IUnitOfWork _unitOfWork;

        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository<TEntity> Members

        /// <summary>
        /// Gets for the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetForId(Int32 id)
        {
            return _unitOfWork.CreateSet<TEntity>().Find(id);
        }

        /// <summary>
        /// Gets for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual TEntity GetForKey(String key)
        {
            return _unitOfWork.CreateSet<TEntity>().Find(key);
        }

        /// <summary>
        /// Gets for the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetForGuid(Guid guid)
        {
            return _unitOfWork.CreateSet<TEntity>().Find(guid);
        }

        /// <summary>
        /// Gets for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public virtual TEntity GetForName(String name)
        {
            return _unitOfWork.CreateSet<TEntity>().Find(name);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<TEntity> GetAll()
        {
            return _unitOfWork.CreateSet<TEntity>().ToList();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual TEntity Create(TEntity entity)
        {
            _unitOfWork.Attach<TEntity>(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            _unitOfWork.SetModified<TEntity>(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            _unitOfWork.Detach<TEntity>(entity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Discards the changes.
        /// </summary>
        public void DiscardChanges()
        {
            _unitOfWork.Rollback();
        }

        /// <summary>
        /// Merges the specified persisted and modified entities.
        /// </summary>
        /// <param name="persisted">The persisted.</param>
        /// <param name="modified">The modified.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Merge(TEntity persisted, TEntity modified)
        {
            _unitOfWork.ApplyCurrentValues(persisted, modified);
        }

        #endregion
    }
}