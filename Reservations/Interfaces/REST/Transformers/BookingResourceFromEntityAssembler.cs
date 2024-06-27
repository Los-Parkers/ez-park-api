using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Interfaces.REST.Resources;

namespace ez_park_platform.Reservations.Interfaces.REST.Transformers
{
    public static class BookingResourceFromEntityAssembler
    {
        public static BookingResource ToResourceFromEntity(Booking entity) =>
            new(entity.Id, entity.HoursRegistered, entity.TotalPrice, entity.StartHour, entity.EndHour, entity.BookingStatus, entity.ParkingId, entity.UserId);
    }
}
