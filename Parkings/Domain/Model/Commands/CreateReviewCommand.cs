namespace ez_park_platform.Parkings.Domain.Model.Commands
{
    public record CreateReviewCommand(int ParkingId, int UserId, int Rating, string Comment);
}
