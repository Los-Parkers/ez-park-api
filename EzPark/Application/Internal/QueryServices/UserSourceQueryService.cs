using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Domain.Model.Querys;
using ez_park_platform.EzPark.Application.Domain.Repositories;
using ez_park_platform.EzPark.Application.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.QueryServices
{
    public class UserSourceQueryService(IUserSourceRepository userSourceRepository) : IUserSourceQueryService
    {
        public async Task<IEnumerable<UserSource>> Handle(GetAllUserSourcesByApiKeyQuery query)
        {
            return await userSourceRepository.FindByApiKeyAsync(query.ApiKey);
        }

        public async Task<UserSource?> Handle(GetUserSourceByIdQuery query)
        {
            return await userSourceRepository.FindByIdAsync(query.Id);
        }

        public async Task<UserSource?> Handle(GetUserSourceByApiKeyandSourceId query)
        {
            return await userSourceRepository.FindByApiKeyAndSourceIdAsync(query.ApiKey, query.SourceId);
        }
    }
}
