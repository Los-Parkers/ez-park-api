namespace ez_park_platform.Users.Domain.Model.ValueObjects
{
    public record UserName(string FirstName, string LastName)
    {
        public UserName() : this(string.Empty, string.Empty) { }

        public UserName(string FirstName) : this(FirstName, string.Empty) { }

        public string FullName => $"{FirstName} {LastName}";

    }
}
