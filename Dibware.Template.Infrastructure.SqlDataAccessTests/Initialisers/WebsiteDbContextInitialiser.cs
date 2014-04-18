using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
using System;
using System.Data.Entity;


namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers
{
    public class WebsiteDbContextInitialiser : DropCreateDatabaseAlways<WebsiteDbContext>
    {
        /// <summary>
        /// Seeds the specified database context.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        protected override void Seed(WebsiteDbContext databaseContext)
        {
            SeedErrors(ref databaseContext);
            SeedRoles(ref databaseContext);
            SeedUsers(ref databaseContext);

            // Commit attachments
            databaseContext.Commit();
        }

        /// <summary>
        /// Seeds the specified database context with Errors.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        private void SeedErrors(ref WebsiteDbContext databaseContext)
        {
            // Create Errors
            var error1 = new Error
            (
                ErrorData.NullReferenceError.Message,
                ErrorData.NullReferenceError.Source,
                ErrorData.NullReferenceError.Message,
                UserData.UserDave.Username,
                DateTime.Today.AddDays(-4)
            )
            {
                Id = 1
            };
            var error2 = new Error
            (
                ErrorData.InvalidOperationError.Message,
                ErrorData.InvalidOperationError.Source,
                ErrorData.InvalidOperationError.Message,
                UserData.UserJane.Username,
                DateTime.Today.AddDays(-3)
            )
            {
                Id = 2
            };

            // Add Errors
            databaseContext.Attach(error1);
            databaseContext.Attach(error2);
        }

        /// <summary>
        /// Seeds the specified database context with roles.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        private static void SeedRoles(ref WebsiteDbContext databaseContext)
        {
            // Create Roles
            var roleAdmin = new Role
            {
                Key = RoleData.RoleAdmin.Key,
                Name = RoleData.RoleAdmin.Name
            };
            var rolePrivate = new Role
            {
                Key = RoleData.RoleMain.Key,
                Name = RoleData.RoleMain.Name
            };
            var roleOrganisation = new Role
            {
                Key = RoleData.RoleSuper.Key,
                Name = RoleData.RoleSuper.Name
            };
            var roleUnknown = new Role
            {
                Key = RoleData.RoleUnknown.Key,
                Name = RoleData.RoleUnknown.Name
            };

            // Add Roles
            databaseContext.Attach(roleAdmin);
            databaseContext.Attach(rolePrivate);
            databaseContext.Attach(roleOrganisation);
            databaseContext.Attach(roleUnknown);
        }

        /// <summary>
        /// Seeds the specified database context with users.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        private static void SeedUsers(ref WebsiteDbContext databaseContext)
        {
            // Create Users
            var userDave = new User
            {
                Guid = UserData.UserDave.Guid,
                //Password = UserData.UserDave.Password,
                Name = UserData.UserDave.Name,
                Username = UserData.UserDave.Username
            };
            var userJane = new User
            {
                Guid = UserData.UserJane.Guid,
                //Password = UserData.UserJane.Password,
                Name = UserData.UserJane.Name,
                Username = UserData.UserJane.Username
            };
            var userPete = new User
            {
                Guid = UserData.UserPete.Guid,
                //Password = UserData.UserPete.Password,
                Name = UserData.UserPete.Name,
                Username = UserData.UserPete.Username
            };

            // Add Users
            databaseContext.Attach(userDave);
            databaseContext.Attach(userJane);
            databaseContext.Attach(userPete);
        }
    }
}