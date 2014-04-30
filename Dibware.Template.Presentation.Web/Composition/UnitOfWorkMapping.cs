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

            // Objects that explicitly need a DB context for the life of the request
            Bind<IUnitOfWorkInRequestScope>()
                .To<WebsiteDbContext>()
                .InRequestScope()
                .WithConstructorArgument(
                    "connectionString",
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);

            // Objects that specificall need a DB context for the life of the application
            Bind<IUnitOfWorkInApplicationScope>()
                .To<WebsiteDbContext>()
                .InSingletonScope()
                .WithConstructorArgument(
                    "connectionString",
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);
        }
    }
}