using System.Threading.Tasks;
using TheBasic.DataLayer.Entities;

namespace TheBasic.DataLayer.Repositories.Interfaces
{
    /// <summary>
    /// Interface for Client Action Repository
    /// </summary>
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns>The customer</returns>
        Task<Customer> GetByIdAsync(int customerId);
    }
}
