using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class ProviderMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryMembershipProvider>()
                .To<RepositoryMembershipProvider>()
                .InThreadScope();
        }
    }
}