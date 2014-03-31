using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Web.Security.Providers.Contracts;
using System;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    public interface IRoleRepository : IRepositoryRoleProviderRepository, IRepository<String>
    {
    }
}