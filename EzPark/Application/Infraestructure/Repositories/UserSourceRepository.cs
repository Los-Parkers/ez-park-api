using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.EzPark.Application.Infraestructure.Repositories
{
    public class UserSourceRepository : BaseRepository<UserSource>, IUserSourceRepository
    {
        public UserSourceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserSource?> FindByApiKeyAndSourceIdAsync(string apiKey, string sourceId)
        {
            return await Context.Set<UserSource>()
                .FirstOrDefaultAsync(u => u.ApiKey == apiKey && u.SourceId == sourceId);
        }

        public async Task<IEnumerable<UserSource>> FindByApiKeyAsync(string apiKey)
        {
            return await Context.Set<UserSource>().Where(u => u.ApiKey == apiKey).ToListAsync();
        }
    }
}
