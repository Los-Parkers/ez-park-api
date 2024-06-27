using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Commands;

namespace ez_park_platform.ParkingManagement.Domain.Services
{
    public interface IReviewCommandService
    {
        Task<Review?> Handle(CreateReviewCommand command);
    }
}