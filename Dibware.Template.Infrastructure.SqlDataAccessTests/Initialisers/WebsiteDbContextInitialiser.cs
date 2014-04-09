using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
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
            SeedRoles(ref databaseContext);
            SeedUsers(ref databaseContext);

            // Commit attachments
            databaseContext.Commit();
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
                UserName = UserData.UserDave.Username
            };
            var userJane = new User
            {
                Guid = UserData.UserJane.Guid,
                //Password = UserData.UserJane.Password,
                Name = UserData.UserJane.Name,
                UserName = UserData.UserJane.Username
            };
            var userPete = new User
            {
                Guid = UserData.UserPete.Guid,
                //Password = UserData.UserPete.Password,
                Name = UserData.UserPete.Name,
                UserName = UserData.UserPete.Username
            };

            // Add Users
            databaseContext.Attach(userDave);
            databaseContext.Attach(userJane);
            databaseContext.Attach(userPete);
        }
    }
}