using System.Data.Entity.ModelConfiguration;
using Dibware.Template.Core.Domain.Entities.Security;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("security.User");

            // Properties
            HasKey(r => r.Guid);

            // Guid
            Property(r => r.Guid)
                .HasColumnName("UserGuid")
                .IsRequired();

            // Password
            Property(r => r.Password)
                .IsRequired()
                .HasMaxLength(50);

            // Name
            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Relationships
            // TODO: To complete when other tables exist.

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName("security.User_Insert")
                    .Parameter(r => r.Password, "Password")
                    .Parameter(r => r.Name, "Name"))
                .Update(u => u
                    .HasName("security.User_Update")
                    .Parameter(r => r.Guid, "Guid")
                    .Parameter(r => r.Password, "Password")
                    .Parameter(r => r.Name, "Name"))
                .Delete(d => d
                    .HasName("security.User_Delete")
                    .Parameter(r => r.Guid, "Guid"))
            );
        }
    }
}