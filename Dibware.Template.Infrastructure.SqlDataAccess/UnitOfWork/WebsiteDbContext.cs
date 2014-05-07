using Dibware.EF.Extensions;
using Dibware.EF.Extensions.Contracts;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork
{
    public class WebsiteDbContext : DbContext,
        IUnitOfWork,
        IUnitOfWorkInRequestScope,
        IUnitOfWorkInApplicationScope
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public WebsiteDbContext(string connectionString)
            : base(connectionString) { }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove all existing conventions
            modelBuilder.Conventions
                .Remove<NavigationPropertyNameForeignKeyDiscoveryConvention>();

            // Security
            modelBuilder.Configurations.Add(new ErrorConfiguration());
            modelBuilder.Configurations.Add(new PasswordStrengthRuleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Creates a set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return Set<TEntity>();
        }

        /// <summary>
        /// Attaches the specified item.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            Set<TEntity>().Add(item);
        }

        /// <summary>
        /// Sets the modified.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Detaches the specified item.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        public void Detach<TEntity>(TEntity item)
            where TEntity : class
        {
            Set<TEntity>().Remove(item);
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <summary>
        /// Apply current values in <paramref name="original" />
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            Entry(original).CurrentValues.SetValues(current);
        }

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <typeparam name="TResult">The type of the result expected.</typeparam>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns></returns>
        public IEnumerable<TResult> ExecuteStoredProcedure<TResult>(IStoredProcedure<TResult> storedProcedure)
            where TResult : class
        {
            try
            {
                //// taken from Dib EF ext... Needs putting back when correct.
                //var sqlCommandString = CommandHelper.CreateStoredProcedureCommandString<TResult>(
                //    storedProcedure.FullName,
                //    storedProcedure.Parameters
                //);
                //var result = Database.SqlQuery<TResult>(
                //    sqlCommandString,
                //    storedProcedure.Parameters.ToArray()).ToList();
                /*procedure.Parameters.Cast<object>().ToArray());*/
                var result = Database.ExecuteStoredProcedure<TResult>(storedProcedure).ToList();
                return result;
            }
            catch (SqlException sqEx)
            {
                throw sqEx;
            }
        }

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parameters">The parameters.</param>
        public int ExecuteStoredProcedure(string procedureName, object parameters)
        {
            var arguments = PrepareSqlArguments(procedureName, parameters);
            return Database.ExecuteSqlCommand(arguments.Item1, arguments.Item2);
        }

        /// <summary>
        /// Executes the scalar stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database">The database.</param>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public TResult ExecuteScalarStoredProcedure<TResult>(IStoredProcedure<TResult> storedProcedure)
            where TResult : struct
        {
            return Database.ExecuteScalarStoredProcedure(storedProcedure);
        }

        /// <summary>
        /// Executes the SQL query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        public ICollection<T> ExecuteSqlQuery<T>(string sqlQuery) where T : class
        {
            return Database.SqlQuery<T>(sqlQuery).ToList();
        }

        //public T ExecuteScalarSqlQuery<T>(String sqlQuery) where T : struct
        //{
        //    return Database

        //}

        #endregion

        #region Private Methods

        /// <summary>
        /// Prepares the SQL parameters.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private static Tuple<String, Object[]> PrepareSqlArguments(String storedProcedure, Object parameters)
        {
            if (String.IsNullOrEmpty(storedProcedure)) { throw new ArgumentNullException(storedProcedure); }

            var parameterNames = new List<String>();
            var parameterParameters = new List<Object>();

            // Resolve parameter object
            if (parameters != null)
            {
                foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
                {
                    var name = "@" + propertyInfo.Name;
                    var value = propertyInfo.GetValue(parameters, null);

                    parameterNames.Add(name);
                    parameterParameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                }
            }

            // Format stored proc with parameter names
            if (parameterNames.Count > 0)
            {
                storedProcedure += " " + String.Join(", ", parameterNames);
            }

            // Add EXEC keyword
            storedProcedure = "EXEC " + storedProcedure;

            // And return the sql arguments tuple
            return new Tuple<String, Object[]>(storedProcedure, parameterParameters.ToArray());
        }

        #endregion
    }
}