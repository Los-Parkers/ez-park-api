using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;

namespace ez_park_platform.Parkings.Domain.Services
{
    public interface IReviewQueryService
    {
        Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
        Task<Review?> Handle(GetReviewByIdQuery query);
        Task<List<Review>> Handle(GetReviewsByUserIdQuery query);
        Task<List<Review>> Handle(GetReviewsByParkingIdQuery query);
    }
}
