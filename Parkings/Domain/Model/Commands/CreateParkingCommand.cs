namespace ez_park_platform.Parkings.Domain.Model.Commands
{
    public record CreateParkingCommand(string Address, double Width, double Length, double Height, int MaxCapacity, int AvailableCapacity, double Price, double Rating, string Phone, string Description);
}
