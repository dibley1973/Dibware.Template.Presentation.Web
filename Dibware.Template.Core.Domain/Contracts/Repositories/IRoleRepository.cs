using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Web.Security.Providers.Contracts;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    public interface IRoleRepository : IRepository<Role>, IRepositoryRoleProviderRepository
    {
        /// <summary>
        /// Gets a list of roles for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        List<Role> GetRoleListForUser(String username);

        /// <summary>
        /// Gets a list of role names for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        List<String> GetRoleNameListsForUser(String username);
    }
}