using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;
using ez_park_platform.Parkings.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.QueryServices
{
    public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
    {
        public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query)
        {
            return await reviewRepository.ListAsync();
        }

        public async Task<Review?> Handle(GetReviewByIdQuery query)
        {
            return await reviewRepository.FindByIdAsync(query.ReviewId);
        }

        public async Task<List<Review>> Handle(GetReviewsByUserIdQuery query)
        {
            return await reviewRepository.FindByUserIdAsync(query.UserId);
        }
        
        public async Task<List<Review>> Handle(GetReviewsByParkingIdQuery query)
        {
            return await reviewRepository.FindByUserIdAsync(query.ParkingId);
        }
        
    }
}