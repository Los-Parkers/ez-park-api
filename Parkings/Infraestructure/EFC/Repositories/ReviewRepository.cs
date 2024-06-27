using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Parkings.Infraestructure.Persistance.EFC.Repositories
{

    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }

        public async Task<List<Review>> FindByUserIdAsync(int userid)
        {
            return await Context.Set<Review>().Where(u => u.UserId == userid).ToListAsync();
        }
        
        public async Task<List<Review>> FindByParkingIdAsync(int parkingid)
        {
            return await Context.Set<Review>().Where(u => u.ParkingId == parkingid).ToListAsync();
        }
    }
}


