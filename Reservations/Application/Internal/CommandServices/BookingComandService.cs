using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Commands;
using ez_park_platform.Reservations.Domain.Repositories;
using ez_park_platform.Reservations.Domain.Services;
using ez_park_platform.Shared.Domain.Repositories;

namespace ez_park_platform.Reservations.Application.Internal.CommandServices
{
    public class BookingComandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork) : IBookingCommandService 
    {
        public async Task<Booking?> Handle(CreateBookingCommand command)
        {
            Booking booking = new(command);

            try
            {
                await bookingRepository.AddAsync(booking);
                await unitOfWork.CompleteAsync();
                return booking;
            }
            catch (Exception e)
            {
                Console.WriteLine($"It seems that something bad happened. {e.Message}");
                return null;
            }
        }

    }
}
