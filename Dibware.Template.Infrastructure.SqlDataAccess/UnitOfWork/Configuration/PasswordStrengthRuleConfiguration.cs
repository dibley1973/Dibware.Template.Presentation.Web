using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class PasswordStrengthRuleConfiguration : EntityTypeConfiguration<PasswordStrengthRule>
    {
        #region Properties

        /// <summary>
        /// Gets the PasswordStrengthRule table name.
        /// </summary>
        /// <value>
        /// The PasswordStrengthRule table.
        /// </value>
        private static String PasswordStrengthRuleTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Security,
                    TableNames.PasswordStrengthRule
                );
            }
        }

        /// <summary>
        /// Gets the name of the PasswordStrengthRule Delete stored procedure.
        /// </summary>
        /// <value>
        /// The PasswordStrengthRule Delete stored procedure.
        /// </value>
        private static String PasswordStrengthRuleDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.PasswordStrengthRule,
                        StoredProcedureAction.Delete
                );
            }
        }

        /// <summary>
        /// Gets the name of the PasswordStrengthRule Insert stored procedure.
        /// </summary>
        /// <value>
        /// The PasswordStrengthRule Insert stored procedure.
        /// </value>
        private static String PasswordStrengthRuleInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.PasswordStrengthRule,
                        StoredProcedureAction.Insert
                );
            }
        }

        /// <summary>
        /// Gets the name of the PasswordStrengthRule Update stored procedure.
        /// </summary>
        /// <value>
        /// The PasswordStrengthRule Update stored procedure.
        /// </value>
        private static String PasswordStrengthRuleUpdateStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.PasswordStrengthRule,
                        StoredProcedureAction.Update
                );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordStrengthRuleConfiguration"/> class.
        /// </summary>
        public PasswordStrengthRuleConfiguration()
        {
            ToTable(PasswordStrengthRuleTableFullName);

            // Properties
            HasKey(e => e.Id);

            // Id
            Property(e => e.Id)
                .HasColumnName(ColumnNames.PasswordStrengthRuleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // RegularExpression
            Property(e => e.RegularExpression)
                .IsRequired()
                .HasMaxLength(128);

            // Description
            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(256);

            // Notes
            Property(e => e.Notes)
                .IsRequired()
                .HasMaxLength(128);

            // Relationships
            // None

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName(PasswordStrengthRuleInsertStoredProcedureName)
                    .Parameter(e => e.RegularExpression, ParameterNames.RegularExpression)
                    .Parameter(e => e.Description, ParameterNames.Description)
                    .Parameter(e => e.Notes, ParameterNames.Notes))
                .Update(u => u
                    .HasName(PasswordStrengthRuleUpdateStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.Id)
                    .Parameter(e => e.RegularExpression, ParameterNames.RegularExpression)
                    .Parameter(e => e.Description, ParameterNames.Description)
                    .Parameter(e => e.Notes, ParameterNames.Notes))
                .Delete(d => d
                    .HasName(PasswordStrengthRuleDeleteStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.Id))
            );
        }

        #endregion
    }
}