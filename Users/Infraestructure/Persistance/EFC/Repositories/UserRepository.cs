using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Users.Infraestructure.Persistance.EFC.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> FindByDniAsync(string Dni)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(u => u.Dni == Dni);
        }
    }
}
