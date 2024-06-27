using ez_park_platform.Parkings.Domain.Model.Commands;

namespace ez_park_platform.Parkings.Domain.Model.Aggregates
{
    public partial class Review
    {
        public int Id { get; }
        public int ParkingId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        
        protected Review()
        {
            this.ParkingId = default;
            this.UserId = default;
            this.Rating = default;
            this.Comment = string.Empty;
        }
        
        public Review(CreateReviewCommand command)
        {
            this.ParkingId = command.ParkingId;
            this.UserId = command.UserId;
            this.Rating = command.Rating;
            this.Comment = command.Comment;
        }
    }
    
    
    
    
}