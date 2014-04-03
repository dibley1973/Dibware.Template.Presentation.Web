using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        #region Properties

        /// <summary>
        /// Gets the role table name.
        /// </summary>
        /// <value>
        /// The role table.
        /// </value>
        private static String RoleTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Security,
                    TableNames.Role
                );
            }
        }

        /// <summary>
        /// Gets the name of the role Delete stored procedure.
        /// </summary>
        /// <value>
        /// The role Delete stored procedure.
        /// </value>
        private static String RoleDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.Role,
                        StoredProcedureAction.Delete
                    );
            }
        }

        /// <summary>
        /// Gets the name of the role Insert stored procedure.
        /// </summary>
        /// <value>
        /// The role Insert stored procedure.
        /// </value>
        private static String RoleInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.Role,
                        StoredProcedureAction.Insert
                    );
            }
        }

        /// <summary>
        /// Gets the name of the role Update stored procedure.
        /// </summary>
        /// <value>
        /// The role Update stored procedure.
        /// </value>
        private static String RoleUpdateStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.Role,
                        StoredProcedureAction.Update
                    );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleConfiguration"/> class.
        /// </summary>
        public RoleConfiguration()
        {
            ToTable(RoleTableFullName);

            // Properties
            HasKey(r => r.Key);

            // Id
            Property(r => r.Key)
                .HasColumnName(ColumnNames.RoleKey)
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
                    .HasName(RoleInsertStoredProcedureName)
                    .Parameter(r => r.Key, ParameterNames.RoleKey)
                    .Parameter(r => r.Name, ParameterNames.Name))
                .Update(u => u
                    .HasName(RoleUpdateStoredProcedureName)
                    .Parameter(r => r.Key, ParameterNames.RoleKey)
                    .Parameter(r => r.Name, ParameterNames.Name))
                .Delete(d => d
                    .HasName(RoleDeleteStoredProcedureName)
                    .Parameter(r => r.Key, ParameterNames.RoleKey))
            );
        }

        #endregion
    }
}