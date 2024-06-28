using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Authentication.Domain.Model.Aggregates;
using ez_park_platform.Authentication.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Authentication.Infraestructure.Persistance.EFC.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> FindByDniAsync(string Dni)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(u => u.Dni == Dni);
        }

        public async Task<User?> FindByEmailAndPasswordAsync(string Email, string Password)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
        }

    }
}
