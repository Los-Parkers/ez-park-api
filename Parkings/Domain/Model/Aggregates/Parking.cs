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
        public double Price { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        
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
            this.UserId = command.UserId;
        }
    }
}