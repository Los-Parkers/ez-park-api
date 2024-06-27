using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;

namespace ez_park_platform.ParkingManagement.Domain.Repositories
{
    public interface IParkingRepository : IBaseRepository<Parking>
    {
        Task<List<Parking>> FindByUserIdAsync(int userid);
    }
}