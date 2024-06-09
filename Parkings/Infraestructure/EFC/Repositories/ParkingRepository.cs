using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Parkings.Infraestructure.Persistance.EFC.Repositories
{

    public class ParkingRepository : BaseRepository<Parking>, IParkingRepository
    {
        public ParkingRepository(AppDbContext context) : base(context) { }
        
    }
}
