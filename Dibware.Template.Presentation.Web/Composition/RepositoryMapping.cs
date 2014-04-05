using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Web.Security.Providers.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class RepositoryMapping : NinjectModule
    {
        /// <summary>
        /// Loads this instance.
        /// </summary>
        public override void Load()
        {
            // Bind the Interface for the Repository for the
            // RepositoryMembershipProvider to an implementation
            Bind<IRepositoryMembershipProviderRepository>()
                .To<UserRepository>()
                .InRequestScope();

            // Bind the Interface for the Repository for the
            // RepositoryMembershipProvider to an implementation
            Bind<IRepositoryRoleProviderRepository>()
                .To<RoleRepository>()
                .InRequestScope();

            Bind<IRoleRepository>()
                .To<RoleRepository>()
                .InRequestScope();
        }
    }
}