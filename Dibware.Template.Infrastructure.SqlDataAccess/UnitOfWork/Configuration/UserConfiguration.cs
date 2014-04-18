using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        #region Properties

        /// <summary>
        /// Gets the User table name.
        /// </summary>
        /// <value>
        /// The User table.
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
        /// Gets the name of the User Delete stored procedure.
        /// </summary>
        /// <value>
        /// The User Delete stored procedure.
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
        /// Gets the name of the User Insert stored procedure.
        /// </summary>
        /// <value>
        /// The User Insert stored procedure.
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
        /// Gets the name of the User Update stored procedure.
        /// </summary>
        /// <value>
        /// The User Update stored procedure.
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

        private static String ValidateUserStoredProcedure
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Security,
                        TableNames.User,
                        StoredProcedureAction.ValidateUser
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

            //// Password
            //Property(r => r.Password)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Name
            Property(r => r.Name)
                .IsRequired()
                .IsMaxLength();
                //.HasMaxLength(50);

            // Password
            Property(r => r.Username)
                .IsRequired()
                .IsMaxLength();

            // Relationships
            // TODO: To complete when other tables exist.

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName(UserInsertStoredProcedureName)
                    //.Parameter(r => r.Password, ParameterNames.Password)
                    .Parameter(r => r.Name, ParameterNames.Name)
                    .Parameter(r => r.Username, ParameterNames.Username))
                .Update(u => u
                    .HasName(UserUpdateStoredProcedureName)
                    .Parameter(r => r.Guid, ParameterNames.Guid)
                    //.Parameter(r => r.Password, ParameterNames.Password)
                    .Parameter(r => r.Name, ParameterNames.Name)
                    .Parameter(r => r.Username, ParameterNames.Username))
                .Delete(d => d
                    .HasName(UserDeleteStoredProcedureName)
                    .Parameter(r => r.Guid, ParameterNames.Guid))
            );
        }

        #endregion
    }
}