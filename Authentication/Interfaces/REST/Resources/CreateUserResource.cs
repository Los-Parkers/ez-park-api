namespace ez_park_platform.Authentication.Interfaces.REST.Resources
{
    public record CreateUserResource(string Email, string Password, string FirstName, string LastName, string Dni, string Phone, DateTime DateOfBirth);
}
