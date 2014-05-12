using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Web.Security.Membership;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class UserMembershipConfiguration : EntityTypeConfiguration<UserMembership>
    {
        #region Properties

        /// <summary>
        /// Gets the UserMembership table name.
        /// </summary>
        /// <value>
        /// The UserMembership table.
        /// </value>
        private static String WebMembershipUserTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Security,
                    TableNames.WebMembershipUser
                );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMembershipConfiguration"/> class.
        /// </summary>
        public UserMembershipConfiguration()
        {
            ToTable(WebMembershipUserTableFullName);

            // Properties
            HasKey(e => e.Guid);

            // Id
            Property(e => e.Guid)
                .HasColumnName(ColumnNames.UserGuid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // UserName
            Property(e => e.Username)
                .HasColumnName(ColumnNames.Username)
                .IsRequired()
                .HasMaxLength(256);

            // Password
            Property(e => e.Password)
                .HasColumnName(ColumnNames.Password)
                .IsRequired()
                .HasMaxLength(128);

            // EmailAddress
            Property(e => e.EmailAddress)
                .HasColumnName(ColumnNames.EmailAddress)
                .IsRequired()
                .HasMaxLength(256);

            // and the rest..s

        }

        #endregion
    }
}
