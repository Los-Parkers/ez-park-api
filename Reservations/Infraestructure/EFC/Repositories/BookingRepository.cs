using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;

namespace ez_park_platform.Reservations.Infraestructure.EFC.Repositories
{

    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context) { }
    
    }
}
