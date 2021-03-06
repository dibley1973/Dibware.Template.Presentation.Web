﻿using Dibware.EF.Extensions.Contracts;
using System.Collections.Generic;
using System.Data.Entity;

namespace Dibware.Template.Core.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Creates the set.
        /// </summary>
        /// <typeoublic param name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// Attaches the specified item.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Sets the modified.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        void SetModified<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Detaches the specified item.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="item">The item.</param>
        void Detach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class;

        /// <summary>
        /// Executes the specified stored procedure.
        /// </summary>
        /// <typeparam name="TResult">The type of the result expected.</typeparam>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns></returns>
        IEnumerable<TResult> ExecuteStoredProcedure<TResult>(IStoredProcedure<TResult> storedProcedure)
            where TResult : class;

        /// <summary>
        /// Executes the scalar stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database">The database.</param>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        TResult ExecuteScalarStoredProcedure<TResult>(IStoredProcedure<TResult> storedProcedure)
            where TResult : struct;

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parameters">The parameters.</param>
        int ExecuteStoredProcedure(string procedureName, object parameters);

        /// <summary>
        /// Executes the SQL query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        ICollection<T> ExecuteSqlQuery<T>(string sqlQuery) where T : class;

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();
    }
}