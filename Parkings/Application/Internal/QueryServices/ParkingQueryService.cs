using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;
using ez_park_platform.Parkings.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.QueryServices
{
    public class ParkingQueryService(IParkingRepository parkingRepository) : IParkingQueryService
    {
        public async Task<IEnumerable<Parking>> Handle(GetAllParkingsQuery query)
        {
            return await parkingRepository.ListAsync();
        }

        public async Task<Parking?> Handle(GetParkingByIdQuery query)
        {
            return await parkingRepository.FindByIdAsync(query.ParkingId);
        }

        public async Task<List<Parking>> Handle(GetParkingsByUserId query)
        {
            return await parkingRepository.FindByUserIdAsync(query.UserId);
        }
        
    }
}