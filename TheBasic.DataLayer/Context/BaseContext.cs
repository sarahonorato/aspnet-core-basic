using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace TheBasic.DataLayer.Context
{
    /// <summary>
    /// The base ef database context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class BaseContext<T> : DbContext where T : DbContext
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        /// <exception cref="System.ArgumentException">The connection string is empty or null. - _connectionString</exception>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && optionsBuilder.IsConfigured == false)
            {
                if (string.IsNullOrWhiteSpace(ConnectionString))
                {
                    ConnectionString = DefaultConnectionString;
                }
                if (string.IsNullOrWhiteSpace(ConnectionString))
                {
                    throw new ArgumentException("The connection string is empty or null.", nameof(ConnectionString));
                }
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Gets the default connection string from configuration for the platform database.
        /// </summary>
        /// <value>
        /// The default connection string.
        /// </value>
        protected virtual string DefaultConnectionString
        {
            get
            {
                var connectionString = string.Empty;
                if (ConfigurationManager.ConnectionStrings != null && ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                }
                return connectionString;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="timeout">The timeout.</param>
        public BaseContext(DbContextOptions<T> options, string connectionString, uint? timeout) : this(options, timeout)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        public BaseContext(string connectionString, uint? timeout) : this(new DbContextOptions<T>(), timeout)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        public BaseContext() : this(new DbContextOptions<T>(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public BaseContext(uint? timeout) : this(new DbContextOptions<T>(), timeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The time out.</param>
        public BaseContext(DbContextOptions<T> options, uint? timeout) : base(options)
        {
            if (timeout.HasValue)
            {
                // ReSharper disable once VirtualMemberCallInConstructor
                Database.SetCommandTimeout((int)timeout);
            }
            //set the db contest options
            DbContextOptions = options;
        }

        /// <summary>
        /// Gets or sets the database context options.
        /// </summary>
        /// <value>
        /// The database context options.
        /// </value>
        public DbContextOptions<T> DbContextOptions { get; protected set; }

        /// <inheritdoc />
        /// <summary>
        /// Releases the allocated resources for this context.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            IsDisposed = true;
        }
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }
    }
}
