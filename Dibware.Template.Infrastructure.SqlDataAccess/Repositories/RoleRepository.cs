using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class RoleRepository : Repository<String>, IRoleRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region RoleRepository

        public String[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public String[] GetRoleNamesForUser(String username)
        {
            throw new NotImplementedException();
        }

        public new String GetForGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public new String GetForId(Int32 id)
        {
            throw new NotImplementedException();
        }

        //public new Role GetForKey(String key)
        //{
        //    throw new NotImplementedException();
        //}

        //public new ICollection<Role> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public string Create(Role entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(string entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(string entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Merge(string persisted, string modified)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}