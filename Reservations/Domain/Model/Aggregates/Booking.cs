using ez_park_platform.Reservations.Domain.Model.Commands;

namespace ez_park_platform.Reservations.Domain.Model.Aggregates
{
    public partial class Booking
    {
        public int Id { get; }

        public string HoursRegistered { get; set; }
        public double TotalPrice { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Review { get; set; }
        public double BookingRating { get; set; }
        public string BookingStatus { get; set;}

        protected Booking()
        {
            this.HoursRegistered = string.Empty;
            this.TotalPrice = default;
            this.StartHour = string.Empty;
            this.EndHour = string.Empty;
            this.Review = string.Empty;
            this.BookingRating = default;
            this.BookingStatus = string.Empty;
        }

        public Booking (CreateBookingCommand command)
        {
            this.HoursRegistered = command.HoursRegistered;
            this.TotalPrice = command.TotalPrice;
            this.StartHour = command.StartHour;
            this.EndHour = command.EndHour;
            this.Review = string.Empty;
            this.BookingRating = default;
            this.BookingStatus = "CREATED";
        }
    }
}
