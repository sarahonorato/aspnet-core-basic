using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheBasic.DataLayer.Context;
using TheBasic.DataLayer.Entities;
using TheBasic.DataLayer.Repositories.Interfaces;

namespace TheBasic.DataLayer.Repositories
{
    /// <summary>
    /// Client Action Repository
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        public CustomerRepository() : this(new SaraDbContext())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomerRepository(SaraDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns>The customer</returns>
        public Task<Customer> GetByIdAsync(int customerId)
        {
            return DbSet.Where(x => x.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
