using ez_park_platform.Authentication.Domain.Model.Aggregates;
using ez_park_platform.Authentication.Domain.Model.Querys;
using ez_park_platform.Authentication.Domain.Repositories;
using ez_park_platform.Authentication.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository userRepository) : IUserQueryService
    {
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
        {
            return await userRepository.ListAsync();
        }

        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.FindByIdAsync(query.UserId);
        }

        public async Task<User?> Handle(GetUserByDniQuery query)
        {
            return await userRepository.FindByDniAsync(query.Dni);
        }

        public async Task<User?> Handle(GetUserByEmailAndPassword query)
        {
            return await userRepository.FindByEmailAndPasswordAsync(query.Email, query.Password);
        }
    }
}
