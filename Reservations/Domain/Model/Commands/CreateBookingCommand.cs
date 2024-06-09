namespace ez_park_platform.Reservations.Domain.Model.Commands
{
    public record CreateBookingCommand(string HoursRegistered, double TotalPrice, string StartHour, string EndHour);
}
