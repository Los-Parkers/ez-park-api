using ez_park_platform.ParkingManagement.Domain.Model.Commands;
using ez_park_platform.ParkingManagement.Interfaces.REST.Resources;

namespace ez_park_platform.ParkingManagement.Interfaces.REST.Transformers
{
    public static class CreateReviewCommandFromResourceAssembler
    {
        public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource) =>
            new(resource.ParkingId, resource.UserId, resource.Rating, resource.Comment);
    }
}