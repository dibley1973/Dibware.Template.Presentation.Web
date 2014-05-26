using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class TermAndConditionConfiguration : EntityTypeConfiguration<TermAndCondition>
    {
        #region Properties

        /// <summary>
        /// Gets the TermAndCondition table name.
        /// </summary>
        /// <value>
        /// The TermAndCondition table.
        /// </value>
        private static String TermAndConditionTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Application,
                    TableNames.TermAndCondition
                );
            }
        }

        /// <summary>
        /// Gets the name of the TermAndCondition Delete stored procedure.
        /// </summary>
        /// <value>
        /// The TermAndCondition Delete stored procedure.
        /// </value>
        private static String TermAndConditionDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.TermAndCondition,
                        StoredProcedureAction.Delete
                    );
            }
        }

        /// <summary>
        /// Gets the name of the TermAndCondition Insert stored procedure.
        /// </summary>
        /// <value>
        /// The TermAndCondition Insert stored procedure.
        /// </value>
        private static String TermAndConditionInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.TermAndCondition,
                        StoredProcedureAction.Insert
                    );
            }
        }

        /// <summary>
        /// Gets the name of the TermAndCondition Update stored procedure.
        /// </summary>
        /// <value>
        /// The TermAndCondition Update stored procedure.
        /// </value>
        private static String TermAndConditionUpdateStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.TermAndCondition,
                        StoredProcedureAction.Update
                    );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="TermAndConditionConfiguration"/> class.
        /// </summary>
        public TermAndConditionConfiguration()
        {
            ToTable(TermAndConditionTableFullName);

            // Properties
            HasKey(e => e.Id);

            // Id
            Property(e => e.Id)
                .HasColumnName(ColumnNames.TermAndConditionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // EffectiveFrom
            Property(e => e.EffectiveFrom)
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
                    .HasName(TermAndConditionInsertStoredProcedureName)
                    .Parameter(e => e.EffectiveFrom, ParameterNames.EffectiveFrom)
                    .Parameter(e => e.Description, ParameterNames.Description))
                .Update(u => u
                    .HasName(TermAndConditionUpdateStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.TermAndConditionId)
                    .Parameter(e => e.EffectiveFrom, ParameterNames.EffectiveFrom)
                    .Parameter(e => e.Description, ParameterNames.Description))
                .Delete(d => d
                    .HasName(TermAndConditionDeleteStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.TermAndConditionId))
            );
        }

        #endregion
    }
}