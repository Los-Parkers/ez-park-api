using ez_park_platform.Authentication.Domain.Model.Querys;
using ez_park_platform.Authentication.Domain.Model.Aggregates;

namespace ez_park_platform.Authentication.Domain.Services
{
    public interface IUserQueryService
    {
        Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
        Task<User?> Handle(GetUserByIdQuery query);
        Task<User?> Handle(GetUserByDniQuery query);
        Task<User?> Handle(GetUserByEmailAndPassword query);
    }
}
