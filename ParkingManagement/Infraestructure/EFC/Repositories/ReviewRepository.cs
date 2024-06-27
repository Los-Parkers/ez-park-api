using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.ParkingManagement.Infraestructure.Persistance.EFC.Repositories
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


