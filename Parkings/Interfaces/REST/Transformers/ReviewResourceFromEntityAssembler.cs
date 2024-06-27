using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Interfaces.REST.Resources;

namespace ez_park_platform.Parkings.Interfaces.REST.Transformers
{
    public static class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity(Review entity)
            => new(entity.Id, entity.Comment, entity.Rating, entity.ParkingId, entity.UserId);
    }
}

