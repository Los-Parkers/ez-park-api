using ez_park_platform.Authentication.Domain.Model.Aggregates;

namespace ez_park_platform.Authentication.Interfaces.ACL
{
    public interface IUserContextFacade
    {

        Task<User?> CreateUser(string Email, string Password, string FirstName, string LastName, string Dni, string Phone, DateTime DateOfBirth);
        Task<User?> FecthUserByDni(string Eni);

        Task<User?> FecthUserById(int Id);
    }
}
