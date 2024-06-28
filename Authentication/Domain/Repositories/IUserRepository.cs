using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Authentication.Domain.Model.Aggregates;

namespace ez_park_platform.Authentication.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByDniAsync(string Dni);
        Task<User?> FindByEmailAndPasswordAsync(string Email, string Password);
    }
}
