using AutoMapper;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Filters;
using Dibware.Template.Presentation.Web.Modules.Authentication;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Web.Security.Principal;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using Ninject.Web.Mvc.FilterBindingSyntax;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Dibware.Template.Presentation.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Handles the PostAuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            String[] roles;
            var applicationConfiguration =
                (IApplicationConfiguration)
                    DependencyResolver.Current.GetService(typeof(IApplicationConfiguration));
            var identity = HttpContext.Current.User.Identity;
            if (Request.IsAuthenticated)
            {
                var roleRepository =
                    (IRoleRepository)DependencyResolver.Current.GetService(typeof(IRoleRepository));
                roles = roleRepository.GetRolesForUser(identity.Name);
            }
            else
            {
                roles = new[] { applicationConfiguration.UnknownUserRoleName };
            }
            var webIdentity = new WebIdentity(identity, roles);
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = applicationConfiguration
            };

            HttpContext.Current.User = principal;
        }

        /// <summary>
        /// Called when the application is started.
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            // Load mapping configuration
            Mapper.Initialize(x => GetMappingConfiguration(Mapper.Configuration));

            // Register any model binders

            // Register any validators
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredIfValidator));

            // Register areas
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>
        /// The created kernel.
        /// </returns>
        protected override IKernel CreateKernel()
        {
            // Get the kernel and load it with teh current assembly
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            //Tell ASP.NET MVC 3 to use our Ninject DI Container
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            // Register any Services
            RegisterServices(kernel);

            // Register any Providers
            RegisterProviders(kernel);

            // Bind any filters that require dependenccy injection
            RegisterGlobalFiltersRequiringInjection(kernel);

            // Return the new kernal
            return kernel;
        }

        /// <summary>
        /// Gets the mapping configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private static void GetMappingConfiguration(IConfiguration configuration)
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }

        /// <summary>
        /// Registers the providers for dependencey injection.
        /// </summary>
        /// <param name="kernel">The Ninject kernel.</param>
        private void RegisterProviders(StandardKernel kernel)
        {
            kernel.Inject(Membership.Provider);
            kernel.Inject(Roles.Provider);
        }

        // <summary>
        /// Registers the providers for dependencey injection.
        /// </summary>
        /// <param name="kernel">The Ninject kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // No services required here yet...
        }

        /// <summary>
        /// Registers any global filters that require dependcy injection.
        /// </summary>
        /// <param name="kernel">The Ninject kernel.</param>
        private static void RegisterGlobalFiltersRequiringInjection(IKernel kernel)
        {
            RegsisterCustomHandleErrorAttribute(kernel);
        }

        /// <summary>
        /// Regsisters the custom handle error attribute.
        /// </summary>
        /// <param name="kernel">The Ninject kernel.</param>
        private static void RegsisterCustomHandleErrorAttribute(IKernel kernel)
        {
            // Get the implementation for the ErrorService
            IErrorService errorService =
                (IErrorService)DependencyResolver.Current
                    .GetService(typeof(IErrorService));

            // get the configuration value for if detailed error
            // messages should be shown or not.
            Boolean showDetailedErrorMesages = Convert.ToBoolean(
                ConfigurationManager.AppSettings[ConfigurationKeys.ShowDetailedErroMessages]);

            // Bind the CustomHandleErrorAttribute
            kernel.BindFilter<CustomHandleErrorAttribute>(FilterScope.Global, 0)
                .WithConstructorArgument("errorService", errorService)
                .WithConstructorArgument("showDetailedErrorMessages", showDetailedErrorMesages);
        }
    }
}