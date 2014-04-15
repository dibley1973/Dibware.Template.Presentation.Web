using Dibware.Template.Core.Application.Services;
using Dibware.Template.Presentation.Web.Resources;
using Dibware.Web.Security.Providers.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Configuration;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class ServiceMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryMembershipProviderPasswordService>()
                .To<PasswordService>()
                .InRequestScope()
                .WithConstructorArgument("hashByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.HashByteSize]))
                .WithConstructorArgument("saltByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.SaltByteSize]))
                .WithConstructorArgument("pbkdf2Iterations", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.PBKDF2Iterations]));
        }
    }
}