using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;

namespace ez_park_platform.ParkingManagement.Domain.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<List<Review>> FindByUserIdAsync(int userid);
        Task<List<Review>> FindByParkingIdAsync(int parkingid);
    }
}