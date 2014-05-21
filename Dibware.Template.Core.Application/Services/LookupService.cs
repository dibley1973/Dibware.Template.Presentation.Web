using Dibware.Template.Core.Application.Resources;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Contracts.Services;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Application.Services
{
    /// <summary>
    /// This service is a quick way to find data from each of the various repositories. 
    /// It makes it easier to use a single service in the classes that use it - 
    /// such as an MVC controller. 
    /// If we need to pick data from multiple repositories for lookup purposes
    /// then we can use a single service rather than having references to all 
    /// the separate services.
    /// </summary>
    public class LookupService : ILookupService
    {
        #region Private Members

        private List<Object> _repositories;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="LookupService"/> class from being created.
        /// </summary>
        private LookupService()
        {
            // Instantiate repository list
            this._repositories = new List<object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupService" /> class.
        /// </summary>
        /// <param name="errorRepository">The error repository.</param>
        /// <param name="membershipRepository">The membership repository.</param>
        /// <param name="passwordStrengthRuleRepository">The password strength rule repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="statusRepository">The status repository.</param>
        public LookupService(
            IErrorRepository errorRepository,
            IMembershipRepository membershipRepository,
            IPasswordStrengthRuleRepository passwordStrengthRuleRepository,
            IRoleRepository roleRepository,
            IStatusRepository statusRepository
        )
            : this()
        {
            // Add all repositories into the list
            this._repositories.Add(errorRepository);
            this._repositories.Add(membershipRepository);
            this._repositories.Add(passwordStrengthRuleRepository);
            this._repositories.Add(roleRepository);
            this._repositories.Add(statusRepository);
        }

        #endregion

        #region ILookupService Members

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public ICollection<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return this.GetRepository<TEntity>().GetAll();
        }

        /// <summary>
        /// Finds the entity by Id from the correct repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public TEntity FindById<TEntity>(int id) where TEntity : class
        {
            return this.GetRepository<TEntity>().GetForId(id);
        }

        /// <summary>
        /// Finds the entity by Key from the correct repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TEntity FindByKey<TEntity>(string key) where TEntity : class
        {
            return this.GetRepository<TEntity>().GetForKey(key);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">returnRepository</exception>
        private IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            // Declare return repository
            IRepository<TEntity> returnRepository = null;

            // Loop tyhrough all repositories in the list
            foreach (var repository in this._repositories)
            {
                // Get base type of the repository
                var baseType = repository.GetType().BaseType;

                // Check the repository meets the conditions that must be met for this service
                if (baseType == null || !baseType.IsGenericType)
                {
                    throw new ApplicationException(ExceptionMessages.RepositoryTypeError);
                }

                // Test to see if repository is of the generic type that we're asking for...
                if (baseType.GetGenericArguments()[0] == typeof(TEntity))
                {
                    returnRepository = (IRepository<TEntity>)repository;
                    break;
                }
            }

            // Test if a repository was found... 
            if (returnRepository == null)
            {
                // ... it wasn't so something's gone poopie!
                throw new ArgumentNullException("returnRepository");
            }
            else
            {
                return returnRepository;
            }
        }

        #endregion
    }
}