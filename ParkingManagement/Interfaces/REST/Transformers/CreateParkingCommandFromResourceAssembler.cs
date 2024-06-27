using ez_park_platform.ParkingManagement.Domain.Model.Commands;
using ez_park_platform.ParkingManagement.Interfaces.REST.Resources;

namespace ez_park_platform.ParkingManagement.Interfaces.REST.Transformers
{
    public static class CreateParkingCommandFromResourceAssembler
    {
        public static CreateParkingCommand ToCommandFromResource(CreateParkingResource resource) =>
            new(resource.Address, resource.Width, resource.Length, resource.Height,  resource.Price, resource.Phone, resource.Description, resource.UserId);
    }
}