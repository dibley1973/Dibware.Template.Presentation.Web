using Dibware.Template.Core.Application.Services;
using Dibware.Template.Core.Domain.Contracts.Services;
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
            //// Bind the Interface for the IRepositoryMembershipProviderPasswordService
            //// to a valid implementation
            //Bind<IRepositoryMembershipProviderPasswordService>()
            //    .To<PasswordService>()
            //    .InRequestScope()
            //    .WithConstructorArgument("hashByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.HashByteSize]))
            //    .WithConstructorArgument("saltByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.SaltByteSize]))
            //    .WithConstructorArgument("pbkdf2Iterations", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.PBKDF2Iterations]))
            //    .WithConstructorArgument("confirmationTokenLength", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.ConfirmationTokenLength]))
            //    .WithConstructorArgument("minRequiredPasswordLength", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.MinRequiredPasswordLength]))
            //    .WithConstructorArgument("minRequiredNonAlphanumericCharacters", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.MinRequiredNonAlphanumericCharacters]))
            //    .WithConstructorArgument("passwordStrengthRegularExpression", ConfigurationManager.AppSettings[ConfigurationKeys.PasswordStrengthRegularExpression]);


            // Bind the Interface for the IRepositoryMembershipProviderPasswordService
            // to a valid implementation
            Bind<IRepositoryMembershipProviderPasswordService>()
                .To<PasswordService>()
                .InRequestScope()
                .WithConstructorArgument("hashByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.HashByteSize]))
                .WithConstructorArgument("saltByteSize", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.SaltByteSize]))
                .WithConstructorArgument("pbkdf2Iterations", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.PBKDF2Iterations]))
                .WithConstructorArgument("confirmationTokenLength", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.ConfirmationTokenLength]))
                .WithConstructorArgument("minRequiredPasswordLength", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.MinRequiredPasswordLength]))
                .WithConstructorArgument("minRequiredNonAlphanumericCharacters", Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationKeys.MinRequiredNonAlphanumericCharacters]));
            //.WithConstructorArgument("passwordStrengthRuleRepository", context => context.Kernel.Get<IPasswordStrengthRuleRepository>(;
            //.WithConstructorArgument("passwordStrengthRuleRepository", Kernel.Get<IPasswordStrengthRuleRepository>());


            Bind<IErrorService>()
                .To<ErrorService>()
                .InRequestScope();
        }
    }
}