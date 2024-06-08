using ez_park_platform.EzPark.Application.Domain.Model.Commands;

namespace ez_park_platform.EzPark.Application.Domain.Model.Aggregates
{
    public class UserSource
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }
        public string SourceId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Dni { get; set; }
        //public string Phone { get; set; }
        //public string BirthDay { get; set; }

        protected UserSource()
        {
            this.ApiKey = string.Empty;
            this.SourceId = string.Empty;
        }


        public UserSource(CreateUserSourceCommand command)
        {
            this.ApiKey = command.ApiKey;
            this.SourceId = command.SourceId;
        }
    }
}
