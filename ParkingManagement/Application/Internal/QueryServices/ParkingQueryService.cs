using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Querys;
using ez_park_platform.ParkingManagement.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Services;

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

        public async Task<List<Parking>> Handle(GetParkingsByUserIdQuery query)
        {
            return await parkingRepository.FindByUserIdAsync(query.UserId);
        }
        
    }
}