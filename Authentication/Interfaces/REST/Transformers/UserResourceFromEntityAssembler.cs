using ez_park_platform.Authentication.Domain.Model.Aggregates;
using ez_park_platform.Authentication.Interfaces.REST.Resources;

namespace ez_park_platform.Authentication.Interfaces.REST.Transformers
{
    public static class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User entity)
            => new(entity.Id, entity.Email, entity.Password, entity.FullName, entity.Phone, entity.Dni, entity.DateOfBirth);
    }
}
