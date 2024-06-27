namespace ez_park_platform.Reservations.Interfaces.REST.Resources
{
    public record CreateBookingResource(int HoursRegistered, double TotalPrice, TimeSpan StartHour, TimeSpan EndHour, Boolean BookingStatus, int ParkingId, int UserId);
}
