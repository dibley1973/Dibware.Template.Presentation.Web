using AutoMapper;
using Dibware.Template.Presentation.Web.Modules.Configuration;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dibware.Template.Presentation.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Called when the application is started.
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            // Load mapping configuration
            Mapper.Initialize(x => GetMappingConfiguration(Mapper.Configuration));

            // Register model binders

            // Register validators
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredIfValidator));

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
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
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
        /// Handles the PostAuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) { return; }

            var applicationConfiguration =
                (IApplicationConfiguration)DependencyResolver.Current.GetService(typeof(IApplicationConfiguration));
            //var roleRepository =
            //    (IRoleRepository)DependencyResolver.Current.GetService(typeof(IRoleRepository));
            //var identity = (IIdentity)HttpContext.Current.User.Identity;
            //var webIdentity = new WebIdentity(identity, roleRepository);

            //// check if user has no roles, and add default role if they don'e
            //if (webIdentity.Roles.Length == 0)
            //{
            //    Array.Resize(ref webIdentity.Roles, webIdentity.Roles.Length + 1);
            //    webIdentity.Roles[webIdentity.Roles.Length - 1] = "Unknown";
            //}

            //var principal = new WebsitePrincipal(webIdentity)
            //{
            //    ApplicationConfiguration = applicationConfiguration
            //};

            //HttpContext.Current.User = principal;
        }

    }
}