using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Domain.Model.Commands;
using ez_park_platform.EzPark.Application.Domain.Repositories;
using ez_park_platform.EzPark.Application.Domain.Services;
using ez_park_platform.Shared.Domain.Repositories;

namespace ez_park_platform.EzPark.Application.Internal.CommandServices
{
    public class UserSourceCommandService(IUserSourceRepository userSourceRepository, IUnitOfWork unitOfWork) : IUserSourceCommandService
    {
        public async Task<UserSource?> Handle(CreateUserSourceCommand command)
        {
            var userSource = await userSourceRepository.FindByApiKeyAndSourceIdAsync(command.ApiKey, command.SourceId);

            if (userSource != null) throw new Exception("User source with this SourceId already exists for the given ApiKey");

            userSource = new UserSource(command);

            try
            {
                await userSourceRepository.AddAsync(userSource);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return userSource;
        }
    }
}
