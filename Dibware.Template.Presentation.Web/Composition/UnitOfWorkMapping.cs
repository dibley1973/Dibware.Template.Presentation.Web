using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Resources.Ninjection;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Syntax;
using System;
using System.Configuration;
using System.Web;
using System.Linq;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class UnitOfWorkMapping : NinjectModule
    {
        public override void Load()
        {
            //TODO: Investigate Contextual Binding 
            // Ref:
            //  https://github.com/ninject/ninject/wiki/Contextual-Binding

            // TODO: get .When(..) to compile!
            // Then use example here
            //  http://stackoverflow.com/questions/23641883/ninject-uow-pattern-new-connectionstring-after-user-is-authenticated
            //
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .InRequestScope()
            //    .When(x => !HttpContext.Current.Request.IsAuthenticated)
            //    .WithConstructorArgument(
            //        "connectionString",
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);
            //
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .InRequestScope()
            //    .When(x => HttpContext.Current.Request.IsAuthenticated)
            //    .WithConstructorArgument(
            //        "connectionString",
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.AuthorisedUser]
            //           .ConnectionString);


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