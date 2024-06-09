namespace ez_park_platform.Parkings.Interfaces.REST.Resources
{
    public record CreateParkingResource(string Address, double Width, double Length, double Height, int MaxCapacity, int AvailableCapacity, double Price, double Rating, string Phone, string Description);
}
