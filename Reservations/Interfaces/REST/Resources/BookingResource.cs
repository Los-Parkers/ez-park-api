namespace ez_park_platform.Reservations.Interfaces.REST.Resources
{
    public record BookingResource(int Id, string HoursRegistered, double TotalPrice, string StartHour, string EndHour, string Review, double BookingRating, string BookingStatus);
}