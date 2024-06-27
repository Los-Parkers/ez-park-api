namespace ez_park_platform.ParkingManagement.Domain.Model.Commands
{
    public record CreateParkingCommand(string Address, double Width, double Length, double Height, double Price, string Phone, string Description, int UserId);
}