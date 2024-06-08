using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Domain.Model.Querys;

namespace ez_park_platform.EzPark.Application.Domain.Services
{
    public interface IUserSourceQueryService
    {
        Task<IEnumerable<UserSource>> Handle(GetAllUserSourcesByApiKeyQuery query);
        Task<UserSource?> Handle(GetUserSourceByIdQuery query);
        Task<UserSource?> Handle(GetUserSourceByApiKeyandSourceId query);
    }
}
