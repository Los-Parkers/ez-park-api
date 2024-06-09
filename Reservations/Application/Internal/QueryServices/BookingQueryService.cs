using ez_park_platform.Parkings.Domain.Model.Querys;
using ez_park_platform.Parkings.Domain.Repositories;
using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Querys;
using ez_park_platform.Reservations.Domain.Repositories;
using ez_park_platform.Reservations.Domain.Services;

namespace ez_park_platform.Reservations.Application.Internal.QueryServices
{
    public class BookingQueryService(IBookingRepository bookingRepository) : IBookingQueryService
    {
        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
        {
            return await bookingRepository.ListAsync();
        }

        public async Task<Booking?> Handle(GetBookingByIdQuery query)
        {
            return await bookingRepository.FindByIdAsync(query.BookingId);
        }
    }
}
