using ez_park_platform.Authentication.Domain.Model.Commands;
using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Commands;

namespace ez_park_platform.Users.Domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(CreateUserCommand command);
        Task<bool> Handle(DeleteUserCommand command);
    }
}
