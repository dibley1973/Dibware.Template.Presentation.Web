﻿using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Web.Security.Providers.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class RepositoryMapping : NinjectModule
    {
        /// <summary>
        /// Loads this instance.
        /// </summary>
        public override void Load()
        {
            #region ErrorRepository

            // Bind the Interface for the ErrorRepository to an implementation
            Bind<IErrorRepository>()
                .To<ErrorRepository>()
                .InSingletonScope();

            #endregion

            #region IMembershipRepository

            // Bind the Interface for the Repository for the
            // RepositoryMembershipProvider to an implementation
            Bind<IMembershipRepository>()
                .To<MembershipRepository>()
                .InSingletonScope();

            #endregion

            #region RepositoryMemberShipProvider Repository

            // Bind the Interface for the Repository for the
            // RepositoryMembershipProvider to an implementation
            Bind<IRepositoryMembershipProviderRepository>()
                .To<MembershipRepository>()
                .InSingletonScope();

            #endregion

            #region RepositoryRoleProvider Repository

            // Bind the Interface for the Repository for the
            // RepositoryRoleProvider to an implementation
            Bind<IRepositoryRoleProviderRepository>()
                .To<RoleRepository>()
                .InSingletonScope();

            #endregion

            #region RoleRepository

            // Bind the Interface for the RoleRepository to an implementation
            Bind<IRoleRepository>()
                .To<RoleRepository>()
                .InRequestScope();

            #endregion

            #region PasswordStrengthRuleRepository

            // Bind the Interface for the PasswordStrengthRuleRepository to 
            // a concrete implementation
            Bind<IPasswordStrengthRuleRepository>()
                .To<PasswordStrengthRuleRepository>()
                .InSingletonScope();

            #endregion

            #region Notification

            Bind<INotificationRepository>()
                .To<NotificationRepository>()
                .InRequestScope();

            #endregion

            #region StatusRepository

            // Bind the Interface for the StatusRepository to a concrete implementation
            Bind<IStatusRepository>()
                .To<StatusRepository>()
                .InRequestScope();

            #endregion

            #region TermAndCondition

            // Bind the Interface for the StatusRepository to a concrete implementation
            Bind<ITermAndConditionRepository>()
                .To<TermAndConditionRepository>()
                .InRequestScope();

            #endregion
        }
    }
}