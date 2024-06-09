using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Commands;

namespace ez_park_platform.Parkings.Domain.Services
{
    public interface IParkingCommandService
    {
        Task<Parking?> Handle(CreateParkingCommand command);
    }
}