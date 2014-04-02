using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using System.Data.Entity;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers
{
    public class WebsiteDbContextInitialiser_Empty : DropCreateDatabaseAlways<WebsiteDbContext>
    {
        protected override void Seed(WebsiteDbContext dbContext)
        {
        }
    }
}