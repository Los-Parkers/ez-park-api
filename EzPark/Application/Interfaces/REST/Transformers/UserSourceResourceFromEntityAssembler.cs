using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;
using ez_park_platform.EzPark.Application.Interfaces.REST.Resources;

namespace ez_park_platform.EzPark.Application.Interfaces.REST.Transformers
{
    public static class UserSourceResourceFromEntityAssembler
    {
        public static UserSourceResource ToResourceFromEntity(UserSource entity) =>
            new UserSourceResource(entity.Id, entity.ApiKey, entity.SourceId);
    }
}
