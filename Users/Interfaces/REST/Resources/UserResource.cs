namespace ez_park_platform.Users.Interfaces.REST.Resources
{
    public record UserResource(int Id, string FullName, string Phone, string Dni, DateTime DateOfBirth);
}
