using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWork UnitOfWork { get; private set; }

        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            return UnitOfWork.CreateSet<TEntity>().Find(id);
        }

        /// <summary>
        /// Gets for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual TEntity GetForKey(String key)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            return UnitOfWork.CreateSet<TEntity>().Find(key);
        }

        /// <summary>
        /// Gets for the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetForGuid(Guid guid)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            return UnitOfWork.CreateSet<TEntity>().Find(guid);
        }

        /// <summary>
        /// Gets for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public virtual TEntity GetForName(String name)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            return UnitOfWork.CreateSet<TEntity>().Find(name);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<TEntity> GetAll()
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            return UnitOfWork.CreateSet<TEntity>().ToList();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual TEntity Create(TEntity entity)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.Attach(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.SetModified(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.Detach(entity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.Commit();
        }

        /// <summary>
        /// Discards the changes.
        /// </summary>
        public void DiscardChanges()
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.Rollback();
        }

        /// <summary>
        /// Merges the specified persisted and modified entities.
        /// </summary>
        /// <param name="persisted">The persisted.</param>
        /// <param name="modified">The modified.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Merge(TEntity persisted, TEntity modified)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            UnitOfWork.ApplyCurrentValues(persisted, modified);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parameters">The parameters.</param>
        public Int32 ExecuteStoredProcedure(String procedureName, params object[] parameters)
        {
            return UnitOfWork.ExecuteStoredProcedure(procedureName, parameters);
        }

        //public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        //{
        //    return UnitOfWork.ExecuteSqlQuery<T>(query, parameters);
        //}

        #endregion
    }
}