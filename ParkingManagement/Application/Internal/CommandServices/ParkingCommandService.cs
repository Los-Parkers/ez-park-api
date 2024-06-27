using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Commands;
using ez_park_platform.ParkingManagement.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.CommandServices
{
    public class ParkingCommandService(IParkingRepository ParkingrRepository, IUnitOfWork unitOfWork) : IParkingCommandService
    {
        public async Task<Parking?> Handle(CreateParkingCommand command)
        {

            Parking parking = new(command);

            try
            {
                await ParkingrRepository.AddAsync(parking);
                await unitOfWork.CompleteAsync();
                return parking;
            }
            catch (Exception e)
            {
                Console.WriteLine($"It seems that something bad happened. {e.Message}");
                return null;
            }
        }
    }
}