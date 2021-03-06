﻿using AutoMapper;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Filters;
using Dibware.Template.Presentation.Web.Modules.PostAuthenticateRequest;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Template.Presentation.Web.Resources.Ninjection;
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
using System.Web.SessionState;

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
            // Get a PostAuthenticateRequestProvider and use this to apply a 
            // correctly configured principal to the current http request
            var provider = (IPostAuthenticateRequestProvider)
                DependencyResolver.Current.GetService(typeof(IPostAuthenticateRequestProvider));
            provider.ApplyPrincipalToHttpRequest(HttpContext.Current);
        }

        /// <summary>
        /// Handles the PreRequestHandlerExecute event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            //Only access session state if it is available
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                //If we are authenticated AND we dont have a session here.. redirect to login page.
                HttpCookie authenticationCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authenticationCookie != null)
                {
                    FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                    if (!authenticationTicket.Expired)
                    {
                        // Check that a session value we set on the login exists
                        if (Session[SessionKeys.IsLoggedIn] == null)
                        {
                            //This means for some reason the session expired before the authentication ticket. Force a login.
                            FormsAuthentication.SignOut();
                            Response.Redirect(FormsAuthentication.LoginUrl, true);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when the application is started.s
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

            // Bind any filters that require dependency injection
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

            //TODO: Implement ApplicationStatus.Provider
            //kernel.Inject(ApplicationStatus.Provider);
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
            RegisterCustomHandleErrorAttribute(kernel);
        }

        /// <summary>
        /// Regsisters the custom handle error attribute.
        /// </summary>
        /// <param name="kernel">The Ninject kernel.</param>
        private static void RegisterCustomHandleErrorAttribute(IKernel kernel)
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
                .When(r => true)
                .WithConstructorArgument(ConstructorArguments.ErrorService, errorService)
                .WithConstructorArgument(ConstructorArguments.ShowDetailedErrorMessages, showDetailedErrorMesages);
        }

        /// <summary>
        /// Handles the Start event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                // Kill off any old authentication
                FormsAuthentication.SignOut();
            }
        }
    }
}