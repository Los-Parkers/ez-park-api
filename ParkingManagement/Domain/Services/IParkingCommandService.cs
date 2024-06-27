using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Commands;

namespace ez_park_platform.ParkingManagement.Domain.Services
{
    public interface IParkingCommandService
    {
        Task<Parking?> Handle(CreateParkingCommand command);
    }
}