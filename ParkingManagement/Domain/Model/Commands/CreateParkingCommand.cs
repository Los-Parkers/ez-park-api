using ez_park_platform.Authentication.Domain.Model.Aggregates;

namespace ez_park_platform.ParkingManagement.Domain.Model.Commands
{
    public record CreateParkingCommand(string Address, double Width, double Length, double Height, double Price, string Phone, string Description,  double Latitude, double Longitude, int UserId);
}