using ez_park_platform.ParkingManagement.Domain.Model.Commands;

namespace ez_park_platform.ParkingManagement.Domain.Model.Entities
{
    public partial class Parking
    {
        public int Id { get; }

        public string Address { get; set; }

        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public int UserId { get; set; }
        

        protected Parking()
        {
            this.Address = string.Empty;
            this.Width = default;
            this.Length = default;
            this.Height = default;
            this.Price = default;
            this.Phone = string.Empty;
            this.Description = string.Empty;
            this.Latitude = default;
            this.Longitude = default;
            this.UserId = default;
        }

        public Parking(CreateParkingCommand command)
        {
            this.Address = command.Address;
            this.Width = command.Width;
            this.Length = command.Length;
            this.Height = command.Height;
            this.Price = command.Price;
            this.Phone = command.Phone;
            this.Description = command.Description;
            this.Latitude = command.Latitude;
            this.Longitude = command.Longitude;
            this.UserId = command.UserId;
        }
    }
}