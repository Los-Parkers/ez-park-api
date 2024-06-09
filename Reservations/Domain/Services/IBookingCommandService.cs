using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Commands;

namespace ez_park_platform.Reservations.Domain.Services
{
    public interface IBookingCommandService
    {
        Task<Booking?> Handle(CreateBookingCommand command);
    }
}
