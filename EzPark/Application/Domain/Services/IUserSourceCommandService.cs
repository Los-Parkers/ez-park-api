using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Domain.Model.Commands;

namespace ez_park_platform.EzPark.Application.Domain.Services
{
    public interface IUserSourceCommandService
    {
        Task<UserSource?> Handle(CreateUserSourceCommand command);
    }
}
