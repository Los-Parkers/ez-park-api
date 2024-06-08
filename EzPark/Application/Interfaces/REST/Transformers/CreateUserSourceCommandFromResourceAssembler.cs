using ez_park_platform.EzPark.Application.Domain.Model.Commands;
using ez_park_platform.EzPark.Application.Interfaces.REST.Resources;

namespace ez_park_platform.EzPark.Application.Interfaces.REST.Transformers
{
    public static class CreateUserSourceCommandFromResourceAssembler
    {
        public static CreateUserSourceCommand ToCommandFromResource(CreateUserSourceResource resource)
            => new CreateUserSourceCommand(resource.ApiKey, resource.SourceId);
    }
}