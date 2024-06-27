using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.ParkingManagement.Infraestructure.Persistance.EFC.Repositories
{

    public class ParkingRepository : BaseRepository<Parking>, IParkingRepository
    {
        public ParkingRepository(AppDbContext context) : base(context) { }

        public async Task<List<Parking>> FindByUserIdAsync(int userid)
        {
            return await Context.Set<Parking>().Where(u => u.UserId == userid).ToListAsync();
        }
    }
}