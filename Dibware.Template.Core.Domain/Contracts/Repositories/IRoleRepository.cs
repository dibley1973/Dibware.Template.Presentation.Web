﻿using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Web.Security.Providers.Contracts;
using System;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role[] GetRolesForUser(String username);
        String[] GetRoleNamesForUser(String username);
    }
}