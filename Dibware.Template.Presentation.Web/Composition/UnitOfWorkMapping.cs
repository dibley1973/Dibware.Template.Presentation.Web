using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Resources.Ninjection;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Configuration;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class UnitOfWorkMapping : NinjectModule
    {
        public override void Load()
        {
            //TODO: Investigate Contextual Binding 
            // Ref:
            //  https://github.com/ninject/ninject/wiki/Contextual-Binding

            Bind<IUnitOfWork>()
                .To<WebsiteDbContext>()
                .InRequestScope()
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);

            // Objects that explicitly need a DB context for the life of the request
            Bind<IUnitOfWorkInRequestScope>()
                .To<WebsiteDbContext>()
                .InRequestScope()
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);

            // Objects that specifically need a DB context for the life of the application
            Bind<IUnitOfWorkInApplicationScope>()
                .To<WebsiteDbContext>()
                .InSingletonScope()
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);
        }

        /// <summary>
        /// Re-Bind the connection string (in case of multi-tenant architecture)
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public void ReBindDataContext(String connectionString)
        {
            Guard.ArgumentIsNotNull(connectionString, "connectionString");

            Unbind<IUnitOfWorkInApplicationScope>();
            Rebind<IUnitOfWorkInApplicationScope>()
                .To<WebsiteDbContext>()
                .InSingletonScope()
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    connectionString);
        }
    }
}