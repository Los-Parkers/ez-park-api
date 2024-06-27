namespace ez_park_platform.ParkingManagement.Interfaces.REST.Resources
{
    public record ParkingResource(int Id, string Address, double Width, double Length, double Height, double Price, string Phone, string Description, int UserId);
}