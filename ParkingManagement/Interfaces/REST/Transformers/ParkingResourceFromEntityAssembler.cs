using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Interfaces.REST.Resources;

namespace ez_park_platform.ParkingManagement.Interfaces.REST.Transformers
{
    public static class ParkingResourceFromEntityAssembler
    {
        public static ParkingResource ToResourceFromEntity(Parking entity)
            => new(entity.Id, entity.Address, entity.Width, entity.Length, entity.Height, entity.Price, entity.Phone, entity.Description, entity.Latitude, entity.Longitude, entity.UserId);
    }
}