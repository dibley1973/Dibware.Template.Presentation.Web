using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        #region Properties

        /// <summary>
        /// Gets the Notification table name.
        /// </summary>
        /// <value>
        /// The Notification table.
        /// </value>
        private static String NotificationTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Application,
                    TableNames.Notification
                );
            }
        }

        /// <summary>
        /// Gets the name of the Notification Delete stored procedure.
        /// </summary>
        /// <value>
        /// The Notification Delete stored procedure.
        /// </value>
        private static String NotificationDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.Notification,
                        StoredProcedureAction.Delete
                    );
            }
        }

        /// <summary>
        /// Gets the name of the Notification Insert stored procedure.
        /// </summary>
        /// <value>
        /// The Notification Insert stored procedure.
        /// </value>
        private static String NotificationInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.Notification,
                        StoredProcedureAction.Insert
                    );
            }
        }

        /// <summary>
        /// Gets the name of the Notification Update stored procedure.
        /// </summary>
        /// <value>
        /// The Notification Update stored procedure.
        /// </value>
        private static String NotificationUpdateStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.Notification,
                        StoredProcedureAction.Update
                    );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationConfiguration"/> class.
        /// </summary>
        public NotificationConfiguration()
        {
            ToTable(NotificationTableFullName);

            // Properties
            HasKey(e => e.Id);

            // Id
            Property(e => e.Id)
                .HasColumnName(ColumnNames.NotificationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // EffectiveFrom
            Property(e => e.EffectiveFrom)
                .IsRequired();

            // EffectiveTo
            Property(e => e.EffectiveTo)
                .IsRequired();

            // Description
            Property(e => e.Description)
                .IsRequired()
                .IsMaxLength();

            // Relationships
            // None

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName(NotificationInsertStoredProcedureName)
                    .Parameter(e => e.EffectiveFrom, ParameterNames.EffectiveFrom)
                    .Parameter(e => e.EffectiveTo, ParameterNames.EffectiveTo)
                    .Parameter(e => e.Description, ParameterNames.Description))
                .Update(u => u
                    .HasName(NotificationUpdateStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.NotificationId)
                    .Parameter(e => e.EffectiveFrom, ParameterNames.EffectiveFrom)
                    .Parameter(e => e.EffectiveTo, ParameterNames.EffectiveTo)
                    .Parameter(e => e.Description, ParameterNames.Description))
                .Delete(d => d
                    .HasName(NotificationDeleteStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.NotificationId))
            );
        }

        #endregion
    }
}