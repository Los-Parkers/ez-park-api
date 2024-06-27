namespace ez_park_platform.ParkingManagement.Domain.Model.Commands
{
    public record CreateReviewCommand(int ParkingId, int UserId, int Rating, string Comment);
}
