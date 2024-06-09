using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Querys;

namespace ez_park_platform.Reservations.Domain.Services
{
    public interface IBookingQueryService
    {
        Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query);
        Task<Booking?> Handle(GetBookingByIdQuery query);
    }
}
