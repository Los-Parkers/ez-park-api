using ez_park_platform.Parkings.Domain.Model.Commands;

namespace ez_park_platform.Parkings.Domain.Model.Aggregates
{
    public partial class Parking
    {
        public int Id { get; }

        public string Address { get; set; }

        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }

        public int MaxCapacity { get; set; }
        public int AvailableCapacity { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        public string Phone { get; set; }
        public string Description { get; set; }
        

        protected Parking()
        {
            this.Address = string.Empty;
            this.Width = default;
            this.Length = default;
            this.Height = default;
            this.MaxCapacity = default;
            this.AvailableCapacity = default;
            this.Price = default;
            this.Rating = default;
            this.Phone = string.Empty;
            this.Description = string.Empty;

        }

        public Parking(CreateParkingCommand command)
        {
            this.Address = command.Address;
            this.Width = command.Width;
            this.Length = command.Length;
            this.Height = command.Height;
            this.MaxCapacity = command.MaxCapacity;
            this.AvailableCapacity = command.AvailableCapacity;
            this.Price = command.Price;
            this.Rating = command.Rating;
            this.Phone = command.Phone;
            this.Description = command.Description;
        }
    }
}
