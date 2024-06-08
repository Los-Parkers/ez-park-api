using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Interfaces.REST.Resources;

namespace ez_park_platform.Users.Interfaces.REST.Transformers
{
    public static class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User entity)
            => new(entity.Id, entity.FullName, entity.Phone, entity.Dni, entity.DateOfBirth);
    }
}
