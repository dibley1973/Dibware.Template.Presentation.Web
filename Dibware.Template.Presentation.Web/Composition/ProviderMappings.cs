using Dibware.Template.Presentation.Web.Modules.ApplicationState;
using Dibware.Template.Presentation.Web.Modules.PostAuthenticateRequest;
using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Ninject.Modules;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class ProviderMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryMembershipProvider>()
                .To<RepositoryMembershipProvider>()
                .InThreadScope();

            Bind<IRepositoryRoleProvider>()
                .To<RepositoryRoleProvider>()
                .InThreadScope();

            Bind<IPostAuthenticateRequestProvider>()
                .To<MvcPostAuthenticateRequestProvider>()
                .InThreadScope();

            Bind<IApplicationStatusProvider>()
                .To<MvcApplicationStatusProvider>()
                .InThreadScope();
        }
    }
}