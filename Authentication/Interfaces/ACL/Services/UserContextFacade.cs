using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Commands;
using ez_park_platform.Users.Domain.Model.Querys;
using ez_park_platform.Users.Domain.Services;

namespace ez_park_platform.Authentication.Interfaces.ACL.Services
{
    public class UserContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IUserContextFacade
    {
        public async Task<User?> CreateUser(string Email, string Password, string FirstName, string LastName, string Dni, string Phone, DateTime DateOfBirth)
        {
            var createUserCommand = new CreateUserCommand(Email,  Password, FirstName, LastName, Dni, Phone, DateOfBirth);
            var user = await userCommandService.Handle(createUserCommand);

            return user;
        }

        public async Task<User?> FecthUserByDni(string Dni)
        {
            var getUserByDniQuery = new GetUserByDniQuery(Dni);
            var user = await userQueryService.Handle(getUserByDniQuery);

            return user;
        }

        public async Task<User?> FecthUserById(int Id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(Id);
            var user = await userQueryService.Handle(getUserByIdQuery);

            return user;
        }

    }
}
