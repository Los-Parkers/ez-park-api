using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Model.Aggregates;

namespace ez_park_platform.Parkings.Domain.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<List<Review>> FindByUserIdAsync(int userid);
        Task<List<Review>> FindByParkingIdAsync(int parkingid);
    }
}