using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Users.Domain.Model.Aggregates;

namespace ez_park_platform.Users.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByDniAsync(string Dni);
    }
}
