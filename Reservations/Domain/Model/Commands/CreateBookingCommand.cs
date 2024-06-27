namespace ez_park_platform.Reservations.Domain.Model.Commands
{
    public record CreateBookingCommand(int HoursRegistered, double TotalPrice, TimeSpan StartHour, TimeSpan EndHour, Boolean BookingStatus, int ParkingId, int UserId);
}
