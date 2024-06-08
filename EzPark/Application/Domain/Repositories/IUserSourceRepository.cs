using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.Shared.Domain.Repositories;

namespace ez_park_platform.EzPark.Application.Domain.Repositories
{
    public interface IUserSourceRepository: IBaseRepository<UserSource>
    {
        Task<IEnumerable<UserSource>>  FindByApiKeyAsync(string apiKey);
        Task<UserSource?> FindByApiKeyAndSourceIdAsync(string apiKey, string sourceId);
    }
}
