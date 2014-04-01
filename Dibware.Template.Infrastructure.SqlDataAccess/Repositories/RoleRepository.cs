using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Web.Security.Providers.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository, IRepositoryRoleProviderRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IRepositoryRoleProviderRepository Members

        void IRepositoryRoleProviderRepository.AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        void IRepositoryRoleProviderRepository.CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        string[] IRepositoryRoleProviderRepository.FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        string[] IRepositoryRoleProviderRepository.GetAllRoles()
        {
            throw new NotImplementedException();
        }

        string[] IRepositoryRoleProviderRepository.GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        string[] IRepositoryRoleProviderRepository.GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        void IRepositoryRoleProviderRepository.RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryRoleProviderRepository.RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRoleRepository Members

        Role[] IRoleRepository.GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        string[] IRoleRepository.GetRoleNamesForUser(string username)
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.GetForGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.GetForId(int id)
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.GetForKey(string key)
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.GetForName(string name)
        {
            throw new NotImplementedException();
        }

        ICollection<Role> IRepository<Role>.GetAll()
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.Create(Role entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Role>.Update(Role entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Role>.Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Role>.Merge(Role persisted, Role modified)
        {
            throw new NotImplementedException();
        }

        void IRepository<Role>.SaveChanges()
        {
            throw new NotImplementedException();
        }

        void IRepository<Role>.DiscardChanges()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}