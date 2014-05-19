using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        #region Properties

        /// <summary>
        /// Gets the Status table name.
        /// </summary>
        /// <value>
        /// The Status table.
        /// </value>
        private static String StatusTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Application,
                    TableNames.Status
                );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusConfiguration"/> class.
        /// </summary>
        public StatusConfiguration()
        {
            ToTable(StatusTableFullName);

            // Properties
            HasKey(s => s.Id);

            // Id
            Property(s => s.Id)
                .HasColumnName(ColumnNames.StatusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Status
            Property(s => s.State)
                .IsRequired();

            // Message
            Property(s => s.Message)
                .IsRequired()
                .IsMaxLength();

            // Relationships
            // TODO: To complete when other tables exist.

        }

        #endregion
    }
}
