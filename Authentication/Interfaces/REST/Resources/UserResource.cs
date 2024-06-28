namespace ez_park_platform.Authentication.Interfaces.REST.Resources
{
    public record UserResource(int Id, string Email, string Password, string FullName, string Phone, string Dni, DateTime DateOfBirth);
}
