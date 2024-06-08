namespace ez_park_platform.Users.Interfaces.REST.Resources
{
    public record CreateUserResource(string FirstName, string LastName, string Dni, string Phone, DateTime DateOfBirth);
}
