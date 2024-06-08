using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Querys;

namespace ez_park_platform.Users.Domain.Services
{
    public interface IUserQueryService
    {
        Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
        Task<User?> Handle(GetUserByIdQuery query);
        Task<User?> Handle(GetUserByDniQuery query);
    }
}
