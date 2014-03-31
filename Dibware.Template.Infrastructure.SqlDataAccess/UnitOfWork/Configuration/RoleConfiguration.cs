using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<String>
    {
        public RoleConfiguration()
        {
            ToTable("security.Role");

            // Properties
            HasKey(r => r);

            // Id
            Property(r => r)
                .HasColumnName("RoleName")
                .IsRequired()
                .HasMaxLength(25);

            // Relationships
            // TODO: To complete when other tables exist.

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName("Role_Insert")
                    .Parameter(r => r, "Name"))
                //.Update(u => u
                //    .HasName("Role_Update")
                //    .Parameter(r => r, "Name"))
                //.Delete(d => d
                //    .HasName("Role_Delete")
                //    .Parameter(r => r, "Name"))
            );
        }
    }
}