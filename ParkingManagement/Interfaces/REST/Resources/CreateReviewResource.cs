namespace ez_park_platform.ParkingManagement.Interfaces.REST.Resources
{
    public record CreateReviewResource(int Rating, int ParkingId, int UserId, string Comment);
}    
    
