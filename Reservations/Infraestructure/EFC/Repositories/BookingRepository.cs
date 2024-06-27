using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Reservations.Infraestructure.EFC.Repositories
{

    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context) { }
        
        public async Task<List<Booking>> FindByUserIdAsync(int userid)
        {
            return await Context.Set<Booking>().Where(u => u.UserId == userid).ToListAsync();
        }
        
        public async Task<List<Booking>> FindByParkingIdAsync(int parkingid)
        {
            return await Context.Set<Booking>().Where(u => u.ParkingId == parkingid).ToListAsync();
        }
    
    }
}
