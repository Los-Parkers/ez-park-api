using ez_park_platform.Users.Domain.Model.Commands;
using ez_park_platform.Users.Domain.Model.ValueObjects;

namespace ez_park_platform.Users.Domain.Model.Aggregates
{
    public partial class User
    {
        public int Id { get; }

        public UserName UserName { get; private set; }
        public string FullName => UserName.FullName;
        public string Dni { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        protected User()
        {
            UserName = new();
            Dni = string.Empty;
            Phone = string.Empty;
            DateOfBirth = default;
        }


        public User(CreateUserCommand command)
        {
            UserName = new(command.FirstName, command.LastName);
            Dni = command.Dni;
            Phone = command.Phone;
            DateOfBirth = command.DateOfBirth;
        }
    }
}
