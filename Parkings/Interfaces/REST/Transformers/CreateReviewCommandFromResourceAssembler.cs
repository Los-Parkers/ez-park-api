using ez_park_platform.Parkings.Domain.Model.Commands;
using ez_park_platform.Parkings.Interfaces.REST.Resources;

namespace ez_park_platform.Parkings.Interfaces.REST.Transformers
{
    public static class CreateReviewCommandFromResourceAssembler
    {
        public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource) =>
            new(resource.ParkingId, resource.UserId, resource.Rating, resource.Comment);
    }
}