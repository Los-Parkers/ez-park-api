using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Querys;

namespace ez_park_platform.ParkingManagement.Domain.Services
{
    public interface IParkingQueryService
    {
        Task<IEnumerable<Parking>> Handle(GetAllParkingsQuery query);
        Task<Parking?> Handle(GetParkingByIdQuery query);
        Task<List<Parking>> Handle(GetParkingsByUserIdQuery query);

    }
}