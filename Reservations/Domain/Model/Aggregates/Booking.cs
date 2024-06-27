using ez_park_platform.Reservations.Domain.Model.Commands;

namespace ez_park_platform.Reservations.Domain.Model.Aggregates
{
    public partial class Booking
    {
        public int Id { get; }

        public int HoursRegistered { get; set; }
        public double TotalPrice { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        
        public Boolean BookingStatus { get; set;}
        public int ParkingId { get; set; }
        public int UserId { get; set; }
        
        protected Booking()
        {
            this.HoursRegistered = default;
            this.TotalPrice = default;
            this.StartHour = default;
            this.EndHour = default;
            this.BookingStatus = default;
            this.ParkingId = default;
            this.UserId = default;
        }

        public Booking(CreateBookingCommand command)
        {
            this.HoursRegistered = command.HoursRegistered;
            this.TotalPrice = command.TotalPrice;
            this.StartHour = command.StartHour;
            this.EndHour = command.EndHour;
            this.BookingStatus = command.BookingStatus;
            this.ParkingId = command.ParkingId;
            this.UserId = command.UserId;
        }
    }
}
