using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TheBasic.DataLayer.Repositories.Interfaces
{
    /// <summary>
    /// Base repository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IBaseRepository<T> : IDisposable
    {
        /// <summary>
        /// Gets all entities in the context.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Gets all entities asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Gets the entity by the specified keys.
        /// </summary>
        /// <param name="keys">The keys that identify the entity.</param>
        /// <returns></returns>
        T Get(params object[] keys);
        /// <summary>
        /// Gets the entity asynchronous.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        Task<T> GetAsync(params object[] keys);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task AddAsync(T entity);
        /// <summary>
        /// Adds the range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(IEnumerable<T> entities);
        /// <summary>
        /// Adds the range of entities asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        bool Update(T entity);
        /// <summary>
        /// Updates the specified entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity);
        /// <summary>
        /// Updates the specified entity and returns it.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T UpdateAndReturn(T entity);
        /// <summary>
        /// Updates the entity and return asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<T> UpdateAndReturnAsync(T entity);
        /// <summary>
        /// Deletes the entity by the specified identifiers.
        /// </summary>
        /// <param name="keys">The key identifiers.</param>
        bool Delete(params object[] keys);
        /// <summary>
        /// Deletes the entity asynchronous.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(params object[] keys);
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
        /// <summary>
        /// Saves the new the entity and returns it.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T InsertAndReturn(T entity);
        /// <summary>
        /// Saves the new the entity and returns it asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<T> InsertAndReturnAsync(T entity);
        /// <summary>
        /// Sets the command timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        void SetCommandTimeout(int timeout);
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// /// <param name="timeout">The timeout.</param>
        /// <param name="parameters">The parameters.</param>
        IQueryable<T> ExecuteQuery(string query, uint? timeout, params object[] parameters);
        /// <summary>
        /// Executes the query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<List<T>> ExecuteQueryAsync(string query, params object[] parameters);
        /// <summary>
        /// Executes the sql query.
        /// </summary>
        /// <param name="sqlQuery">The sql query.</param>        
        /// <param name="timeout">The command timeout in seconds for the query.</param>
        /// <param name="parameters">The parameters.</param>
        int ExecuteSqlCommand(string sqlQuery, uint? timeout, params object[] parameters);
        /// <summary>
        /// Executes the SQL command asynchronous.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<int> ExecuteSqlCommandAsync(string sqlQuery, params object[] parameters);
        /// <summary>
        /// Executes the delegate on the data set.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
