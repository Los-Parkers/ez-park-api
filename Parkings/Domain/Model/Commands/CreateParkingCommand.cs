namespace ez_park_platform.Parkings.Domain.Model.Commands
{
    public record CreateParkingCommand(string Address, string Width, string Length, string Heigth, int MaxCapacity, int AvailableCapacity, float Price, float Rating, int Phone, string Description);
}
