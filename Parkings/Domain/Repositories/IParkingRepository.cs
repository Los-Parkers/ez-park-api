using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Model.Aggregates;

namespace ez_park_platform.Parkings.Domain.Repositories
{
    public interface IParkingRepository : IBaseRepository<Parking>
    {
        Task<List<Parking>> FindByUserIdAsync(int userid);
    }
}