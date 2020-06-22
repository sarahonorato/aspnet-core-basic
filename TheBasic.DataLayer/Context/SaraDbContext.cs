using Microsoft.EntityFrameworkCore;
using TheBasic.DataLayer.Entities;

namespace TheBasic.DataLayer.Context
{
    /// <summary>
    /// SaraDbContext context
    /// </summary>
    public class SaraDbContext : BaseContext<SaraDbContext>
    {
        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        /// <value>
        /// The Country
        /// </value>
        public virtual DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Gets or sets the states
        /// </summary>
        /// <value>
        /// The states
        /// </value>
        public virtual DbSet<State> States { get; set; }
        /// <summary>
        /// Gets or sets the customers
        /// </summary>
        /// <value>
        /// The customers
        /// </value>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the address
        /// </summary>
        /// <value>
        /// The address
        /// </value>
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="SaraDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="timeout">The timeout.</param>
        public SaraDbContext(DbContextOptions<SaraDbContext> options, string connectionString, uint? timeout = null) :
            base(options, connectionString, timeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaraDbContext"/> class.
        /// </summary>
        public SaraDbContext(string connectionString, uint? timeout = null) : base(connectionString, timeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaraDbContext"/> class.
        /// </summary>
        public SaraDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaraDbContext"/> class.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public SaraDbContext(uint? timeout) : base(timeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaraDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The time out.</param>
        public SaraDbContext(DbContextOptions<SaraDbContext> options, uint? timeout) : base(options, timeout)
        {
        }
        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
