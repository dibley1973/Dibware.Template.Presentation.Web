using Dibware.Template.Core.Domain.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("security.Role");

            // Properties
            HasKey(r => r.Key);

            // Id
            Property(r => r.Key)
                .HasColumnName("RoleKey")
                .IsRequired()
                .HasMaxLength(25);

            // Name
            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            // Relationships
            // TODO: To complete when other tables exist.

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName("Role_Insert")
                    .Parameter(r => r.Name, "Name"))
                .Update(u => u
                    .HasName("Role_Update")
                    .Parameter(r => r.Key, "RoleKey")
                    .Parameter(r => r.Name, "Name"))
                .Delete(d => d
                    .HasName("Role_Delete")
                    .Parameter(r => r.Key, "RoleKey"))
            );
        }
    }
}