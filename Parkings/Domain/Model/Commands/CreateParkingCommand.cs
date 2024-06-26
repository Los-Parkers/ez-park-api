namespace ez_park_platform.Parkings.Domain.Model.Commands
{
    public record CreateParkingCommand(string Address, double Width, double Length, double Height, double Price, string Phone, string Description, int UserId);
}