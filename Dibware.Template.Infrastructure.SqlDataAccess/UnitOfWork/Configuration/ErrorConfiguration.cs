using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration
{
    public class ErrorConfiguration : EntityTypeConfiguration<Error>
    {
        #region Properties

        /// <summary>
        /// Gets the Error table name.
        /// </summary>
        /// <value>
        /// The Error table.
        /// </value>
        private static String ErrorTableFullName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullTableName(
                    SchemaNames.Application,
                    TableNames.Error
                );
            }
        }

        /// <summary>
        /// Gets the name of the Error Delete stored procedure.
        /// </summary>
        /// <value>
        /// The Error Delete stored procedure.
        /// </value>
        private static String ErrorDeleteStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.Error,
                        StoredProcedureAction.Delete
                    );
            }
        }

        /// <summary>
        /// Gets the name of the Error Insert stored procedure.
        /// </summary>
        /// <value>
        /// The Error Insert stored procedure.
        /// </value>
        private static String ErrorInsertStoredProcedureName
        {
            get
            {
                return DatabaseObjectNameHelper.GetFullStoredProcedureName(
                        SchemaNames.Application,
                        TableNames.Error,
                        StoredProcedureAction.Insert
                    );
            }
        }

        ///// <summary>
        ///// Gets the name of the Error Update stored procedure.
        ///// </summary>
        ///// <value>
        ///// The Error Update stored procedure.
        ///// </value>
        //private static String ErrorUpdateStoredProcedureName
        //{
        //    get
        //    {
        //        return DatabaseObjectNameHelper.GetFullStoredProcedureName(
        //                SchemaNames.Application,
        //                TableNames.Error,
        //                StoredProcedureAction.Update
        //            );
        //    }
        //}

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorConfiguration"/> class.
        /// </summary>
        public ErrorConfiguration()
        {
            ToTable(ErrorTableFullName);

            // Properties
            HasKey(e => e.Id);

            // Id
            Property(e => e.Id)
                .HasColumnName(ColumnNames.ErrorId)
                .IsRequired();

            // Message
            Property(e => e.Message)
                .IsRequired()
                .IsMaxLength();

            // Source
            Property(e => e.Source)
                .IsRequired()
                .IsMaxLength();

            // StackTrace
            Property(e => e.StackTrace)
                .IsRequired()
                .IsMaxLength();

            // TimeStamp
            Property(e => e.TimeStamp)
                .IsRequired();

            // Relationships
            // None

            // Stored Procs
            MapToStoredProcedures(s => s
                .Insert(i => i
                    .HasName(ErrorInsertStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.ErrorId)
                    .Parameter(e => e.Message, ParameterNames.Message)
                    .Parameter(e => e.Source, ParameterNames.Source)
                    .Parameter(e => e.StackTrace, ParameterNames.StackTrace)
                    .Parameter(e => e.Username, ParameterNames.Source)
                    .Parameter(e => e.TimeStamp, ParameterNames.TimeStamp))
                //.Update(u => u
                //    .HasName(ErrorUpdateStoredProcedureName)
                //    .Parameter(e => e.Key, ParameterNames.ErrorKey)
                //    .Parameter(e => e.Name, ParameterNames.Name))
                .Delete(d => d
                    .HasName(ErrorDeleteStoredProcedureName)
                    .Parameter(e => e.Id, ParameterNames.ErrorId))
            );
        }

        #endregion
    }
}