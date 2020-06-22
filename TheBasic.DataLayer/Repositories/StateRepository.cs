using TheBasic.DataLayer.Context;
using TheBasic.DataLayer.Entities;
using TheBasic.DataLayer.Repositories.Interfaces;

namespace TheBasic.DataLayer.Repositories
{
    /// <summary>
    /// State Repository
    /// </summary>
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateRepository"/> class.
        /// </summary>
        public StateRepository() : this(new SaraDbContext())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StateRepository(SaraDbContext context) : base(context)
        {
        }
    }
}
