namespace ez_park_platform.Reservations.Interfaces.REST.Resources
{
    public record CreateBookingResource(string HoursRegistered, double TotalPrice, string StartHour, string EndHour);
}
