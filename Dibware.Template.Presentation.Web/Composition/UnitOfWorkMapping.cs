using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Presentation.Web.Resources;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Configuration;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class UnitOfWorkMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>()
                .To<WebsiteDbContext>()
                .InRequestScope()
                .WithConstructorArgument(
                    "connectionString",
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);
        }
    }
}