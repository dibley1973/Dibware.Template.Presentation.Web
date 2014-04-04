using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class RepositoryMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleRepository>()
                .To<RoleRepository>()
                .InRequestScope();

        }
    }
}