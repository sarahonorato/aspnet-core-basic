using TheBasic.DataLayer.Context;
using TheBasic.DataLayer.Entities;
using TheBasic.DataLayer.Repositories.Interfaces;

namespace TheBasic.DataLayer.Repositories
{
    /// <summary>
    /// Address Repository
    /// </summary>
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        public AddressRepository() : this(new SaraDbContext())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AddressRepository(SaraDbContext context) : base(context)
        {
        }
    }
}
