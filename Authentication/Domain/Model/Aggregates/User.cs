using ez_park_platform.Users.Domain.Model.Commands;
using ez_park_platform.Users.Domain.Model.ValueObjects;

namespace ez_park_platform.Users.Domain.Model.Aggregates
{
    public partial class User
    {
        public int Id { get; }

        public string Email { get; set; }
        public string Password { get; set; }

        public UserName UserName { get; private set; }
        public string FullName => UserName.FullName;
        public string Dni { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        protected User()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.UserName = new();
            this.Dni = string.Empty;
            this.Phone = string.Empty;
            this.DateOfBirth = default;
        }


        public User(CreateUserCommand command)
        {
            this.Email = command.Email;
            this.Password = command.Password;
            this.UserName = new(command.FirstName, command.LastName);
            this.Dni = command.Dni;
            this.Phone = command.Phone;
            this.DateOfBirth = command.DateOfBirth;
        }
    }
}
