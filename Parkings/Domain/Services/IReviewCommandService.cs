using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Commands;

namespace ez_park_platform.Parkings.Domain.Services
{
    public interface IReviewCommandService
    {
        Task<Review?> Handle(CreateReviewCommand command);
    }
}