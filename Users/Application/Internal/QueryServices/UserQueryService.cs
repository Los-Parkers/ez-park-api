using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Querys;
using ez_park_platform.Users.Domain.Repositories;
using ez_park_platform.Users.Domain.Services;

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
            return await userRepository.FindUserByDni(query.Dni);
        }
    }
}
