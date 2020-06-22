using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheBasic.DataLayer.Repositories.Interfaces;

namespace TheBasic.DataLayer.Repositories
{
    /// <summary>
    /// The base class to perform CRUD actions for database objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>The default database is SaraDb database.</remarks>
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// The disposed flag.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The database context wrapper.
        /// </summary>
        public readonly DbContext Context;

        /// <summary>
        /// Gets or sets the database set.
        /// </summary>
        /// <value>
        /// The database set.
        /// </value>
        protected DbSet<T> DbSet
        {
            get; set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException($"{nameof(context)}", $"Instance of {nameof(context)} is null.");
            DbSet = Context.Set<T>();
        }

        /// <summary>
        /// Gets all entities in the context.
        /// <remarks>
        /// Please use this for a small data set as it can cause a memory overflow exception for a very large data set.
        /// Consider using Where method to narrow down your data set.
        /// </remarks>
        /// </summary>
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Gets all entities in the context. 
        /// Please note that the entities are not being tracked.
        /// <remarks>
        /// Please use this for a small data set as it can cause a memory overflow exception for a very large data set.
        /// Consider using Where method to narrow down your data set.
        /// </remarks>
        /// </summary>        
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// Gets the entity by the specified keys.
        /// </summary>
        /// <param name="keys">The keys that identify the entity.</param>
        /// <returns></returns>
        public virtual T Get(params object[] keys)
        {
            return DbSet.Find(keys);
        }
        /// <inheritdoc />
        /// <summary>
        /// Gets the entity asynchronous.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }
        /// <inheritdoc />
        /// <summary>
        /// Adds the range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
        /// <inheritdoc />
        /// <summary>
        /// Adds the range of entities asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<T> entities) => await DbSet.AddRangeAsync(entities);

        /// <inheritdoc />
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
        /// <inheritdoc />
        /// <summary>
        /// Updates the specified entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync() > 0;
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the specified entity and returns it.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual T UpdateAndReturn(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Updates the entity and return it asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task<T> UpdateAndReturnAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes the entity by the specified identifiers.
        /// </summary>
        /// <param name="keys">The key identifiers.</param>
        public virtual bool Delete(params object[] keys)
        {
            DbSet.Remove(DbSet.Find(keys));
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// Deletes the entity asynchronous.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(params object[] keys)
        {
            var entities = await DbSet.FindAsync(keys);
            DbSet.Remove(entities);
            return await Context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
        /// <summary>
        /// Saves the new the entity and returns it.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T InsertAndReturn(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Saves the new the entity and returns it asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task<T> InsertAndReturnAsync(T entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Sets the command timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public virtual void SetCommandTimeout(int timeout)
        {
            Context.Database.SetCommandTimeout(timeout);
        }
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// /// <param name="timeout">The timeout in seconds.</param>
        /// <param name="parameters">The parameters.</param>
        public virtual IQueryable<T> ExecuteQuery(string query, uint? timeout, params object[] parameters)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
            IQueryable<T> result;
            if (timeout.HasValue && timeout > 0)
            {
                var oldTimeout = Context.Database.GetCommandTimeout();
                Context.Database.SetCommandTimeout((int)timeout);

                result = ExecuteSql(query, parameters);

                //Reset timeout
                Context.Database.SetCommandTimeout(oldTimeout);
            }
            else
            {
                result = ExecuteSql(query, parameters);
            }

            return result;
        }
        /// <inheritdoc />
        /// <summary>
        /// Executes the query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual async Task<List<T>> ExecuteQueryAsync(string query, params object[] parameters)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
            List<T> result;

            if (parameters == null || parameters.Length == 0)
            {
                result = await DbSet.FromSqlRaw(query).AsNoTracking().ToListAsync();
            }
            else
            {
                result = await DbSet.FromSqlRaw(query, parameters).AsNoTracking().ToListAsync();
            }
            return result;
        }

        /// <summary>
        /// Executes the SQL.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private IQueryable<T> ExecuteSql(string query, params object[] parameters)
        {
            IQueryable<T> result;

            if (parameters == null || parameters.Length == 0)
            {
                result = DbSet.FromSqlRaw(query);
            }
            else
            {
                result = DbSet.FromSqlRaw(query, parameters);
            }
            return result;
        }

        /// <summary>
        /// Executes the SQL command asynchronous.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual async Task<int> ExecuteSqlCommandAsync(string sqlQuery, params object[] parameters)
        {
            return await Context.Database.ExecuteSqlRawAsync(sqlQuery, parameters: parameters);
        }

        /// <summary>
        /// Filters the db set using a delegate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        /// <summary>
        /// Executes the non sql query.
        /// </summary>
        /// <param name="sqlQuery">The sql query.</param>        
        /// <param name="timeout">The command timeout in seconds for the query.</param>
        /// <param name="parameters">The parameters.</param>
        public virtual int ExecuteSqlCommand(string sqlQuery, uint? timeout, params object[] parameters)
        {
            if (!timeout.HasValue || !(timeout > 0))
            {
                return Context.Database.ExecuteSqlRaw(sqlQuery, parameters);
            }

            var oldTimeout = Context.Database.GetCommandTimeout();
            Context.Database.SetCommandTimeout((int)timeout);
            var count = Context.Database.ExecuteSqlRaw(sqlQuery, parameters);

            //Reset timeout
            Context.Database.SetCommandTimeout(oldTimeout);

            return count;

        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Clean-up any resources that the class may have allocated.
        /// </summary>
        /// <param name="disposing">[in] Flag indicating that managed resources need to be cleaned up.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clean-up managed objects here
                    Context?.Dispose();
                }

                // Clean-up unmanaged objects here


                _disposed = true;
            }
        }

        /// <summary>
        /// Clean-up any unmanaged resources that the class may have allocated.
        /// </summary>
        ~BaseRepository()
        {
            Dispose(false);
        }
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed => _disposed;
    }
}
