using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Web.Security.Providers.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IRoleRepository Members

        /// <summary>
        /// Gets a list of roles for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IEnumerable<Role> IRoleRepository.GetRoleListForUser(String username)
        {
            // Validate dependencies and arguments
            Guard.InvalidOperation(UnitOfWork == null, ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of role names for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IEnumerable<String> IRoleRepository.GetRoleNameListsForUser(String username)
        {
            // Validate dependencies and arguments
            Guard.InvalidOperation(UnitOfWork == null, ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            throw new NotImplementedException();
        }

        #endregion

        #region Repository<Role> Members

        /// <summary>
        /// Gets for unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public new Role GetForGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets for identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public new Role GetForId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public new Role GetForKey(String key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets for name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public new Role GetForName(String name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public new ICollection<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public new Role Create(Role entity)
        {
            throw new NotImplementedException();
        }

        public new void Update(Role entity)
        {
            throw new NotImplementedException();
        }

        public new void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public new void Merge(Role persisted, Role modified)
        {
            throw new NotImplementedException();
        }

        public new void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public new void DiscardChanges()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepositoryRoleProviderRepository Members

        void IRepositoryRoleProviderRepository.AddUsersToRoles(String[] usernames, String[] roleNames)
        {
            throw new NotImplementedException();
        }

        void IRepositoryRoleProviderRepository.CreateRole(String roleName)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.DeleteRole(String roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        String[] IRepositoryRoleProviderRepository.FindUsersInRole(String roleName, String usernameToMatch)
        {
            throw new NotImplementedException();
        }

        String[] IRepositoryRoleProviderRepository.GetAllRoles()
        {
            throw new NotImplementedException();
        }

        String[] IRepositoryRoleProviderRepository.GetRolesForUser(String username)
        {
            throw new NotImplementedException();
        }

        String[] IRepositoryRoleProviderRepository.GetUsersInRole(String roleName)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.IsUserInRole(String username, String roleName)
        {
            throw new NotImplementedException();
        }

        void IRepositoryRoleProviderRepository.RemoveUsersFromRoles(String[] usernames, String[] roleNames)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.RoleExists(String roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}