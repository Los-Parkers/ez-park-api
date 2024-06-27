using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Interfaces.REST.Resources;

namespace ez_park_platform.ParkingManagement.Interfaces.REST.Transformers
{
    public static class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity(Review entity)
            => new(entity.Id, entity.Comment, entity.Rating, entity.ParkingId, entity.UserId);
    }
}

