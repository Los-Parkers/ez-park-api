using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Commands;
using ez_park_platform.Parkings.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.CommandServices
{
    public class ReviewCommandService(IReviewRepository ReviewRepository, IUnitOfWork unitOfWork) : IReviewCommandService
    {
        public async Task<Review?> Handle(CreateReviewCommand command)
        {

            Review review = new(command);

            try
            {
                await ReviewRepository.AddAsync(review);
                await unitOfWork.CompleteAsync();
                return review;
            }
            catch (Exception e)
            {
                Console.WriteLine($"It seems that something bad happened. {e.Message}");
                return null;
            }
        }
    }
}