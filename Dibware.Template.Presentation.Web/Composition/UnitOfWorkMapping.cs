using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Resources.Ninjection;
using Ninject.Activation;
using Ninject.Modules;
using System;
using System.Configuration;
using System.Web;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class UnitOfWorkMapping : NinjectModule
    {
        //TODO: Investigate Contextual Binding 
        // Ref:
        //  https://github.com/ninject/ninject/wiki/Contextual-Binding
        //  http://stackoverflow.com/questions/23641883/ninject-uow-pattern-new-connectionstring-after-user-is-authenticated

        /// <summary>
        /// Loads this module mapping.
        /// </summary>
        public override void Load()
        {
            // Bind the IUnitOfWork for a user that IS logged in.
            Bind<IUnitOfWork>()
                .To<WebsiteDbContext>()
                .When(request => IsUserAuthenticated(request))
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.MainUserConnectionString]
                        .ConnectionString);

            // Bind the IUnitOfWork for a user that IS NOT logged in.
            Bind<IUnitOfWork>()
                .To<WebsiteDbContext>()
                .When(request => !IsUserAuthenticated(request))
                .WithConstructorArgument(
                    ConstructorArguments.ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
                        .ConnectionString);

            //// Bind the IUnitOfWork specifically for the RoleRepository.
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .WhenInjectedInto<RoleRepository>()
            //    .WithConstructorArgument(
            //        ConstructorArguments.ConnectionString,
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.MainUserConnectionString]
            //            .ConnectionString);

            //// Bind the IUnitOfWork the PasswordStrengthRuleRepository.
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .WhenInjectedExactlyInto<PasswordStrengthRuleRepository>()
            //    .InRequestScope()
            //    .WithConstructorArgument(
            //        "connectionString",
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);

            //// Bind the IUnitOfWork the MembershipRepository.
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .WhenInjectedExactlyInto<MembershipRepository>()
            //    .InSingletonScope()
            //    .WithConstructorArgument(
            //        "connectionString",
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);

            //// Bind the IUnitOfWork the RoleRepository .
            //Bind<IUnitOfWork>()
            //    .To<WebsiteDbContext>()
            //    .WhenInjectedExactlyInto<RoleRepository>()
            //    .InSingletonScope()
            //    .WithConstructorArgument(
            //        "connectionString",
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);

            //// Objects that explicitly need a DB context for the life of the request
            //Bind<IUnitOfWorkInRequestScope>()
            //    .To<WebsiteDbContext>()
            //    .InRequestScope()
            //    .WithConstructorArgument(
            //        ConstructorArguments.ConnectionString,
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);

            //// Objects that specifically need a DB context for the life of the application
            //Bind<IUnitOfWorkInApplicationScope>()
            //    .To<WebsiteDbContext>()
            //    .InSingletonScope()
            //    .WithConstructorArgument(
            //        ConstructorArguments.ConnectionString,
            //        ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
            //            .ConnectionString);
        }

        /// <summary>
        /// Determines if the user authenticated.
        /// </summary>
        /// <param name="request">The Ninject Activation request.</param>
        /// <returns>
        /// returns <c>true</c> if the user exists and is authenticated
        /// </returns>
        public Boolean IsUserAuthenticated(IRequest request)
        {
            return (
                HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity.IsAuthenticated);
        }
    }
}
