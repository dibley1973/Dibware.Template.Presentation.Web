using System;
using System.Data.Entity.ModelConfiguration;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        #region Properties

        /// <summary>
        /// Gets the role table name.
        /// </summary>
        /// <value>
        /// The role table.
        /// </value>
        private static String UserTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Security,
                    TableNames.User
                );
            }
        }

        /// <summary>
        /// Gets the name of the role Delete stored procedure.
        /// </summary>
        /// <value>
        /// The role Delete stored procedure.
        /// </value>
        private static String UserDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.User,
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
        private static String UserInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.User,
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
        private static String UserUpdateStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.User,
                        StoredProcedureAction.Update
                    );
            }
        }

        #endregion

        #region Methods

        public UserConfiguration()
        {
            ToTable(UserTableFullName);

            // Properties
            HasKey(r => r.Guid);

            // Guid
            Property(r => r.Guid)
                .HasColumnName(ColumnNames.UserGuid)
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
                    .HasName(UserInsertStoredProcedureName)
                    .Parameter(r => r.Password, ParameterNames.Password)
                    .Parameter(r => r.Name, ParameterNames.Name))
                .Update(u => u
                    .HasName(UserUpdateStoredProcedureName)
                    .Parameter(r => r.Guid, ParameterNames.Guid)
                    .Parameter(r => r.Password, ParameterNames.Password)
                    .Parameter(r => r.Name, ParameterNames.Name))
                .Delete(d => d
                    .HasName(UserDeleteStoredProcedureName)
                    .Parameter(r => r.Guid, ParameterNames.Guid))
            );
        }

        #endregion
    }
}