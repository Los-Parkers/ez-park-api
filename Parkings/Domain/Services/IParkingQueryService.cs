using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;

namespace ez_park_platform.Parkings.Domain.Services
{
    public interface IParkingQueryService
    {
        Task<IEnumerable<Parking>> Handle(GetAllParkingsQuery query);
        Task<Parking?> Handle(GetParkingByIdQuery query);
        Task<List<Parking>> Handle(GetParkingsByUserId query);

    }
}