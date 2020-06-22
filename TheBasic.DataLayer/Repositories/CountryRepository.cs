using TheBasic.DataLayer.Context;
using TheBasic.DataLayer.Entities;
using TheBasic.DataLayer.Repositories.Interfaces;

namespace TheBasic.DataLayer.Repositories
{
    /// <summary>
    /// Country Repository
    /// </summary>
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        public CountryRepository() : this(new SaraDbContext())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CountryRepository(SaraDbContext context) : base(context)
        {
        }
    }
}
