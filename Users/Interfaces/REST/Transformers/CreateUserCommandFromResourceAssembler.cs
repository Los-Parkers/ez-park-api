using ez_park_platform.Users.Domain.Model.Commands;
using ez_park_platform.Users.Interfaces.REST.Resources;

namespace ez_park_platform.Users.Interfaces.REST.Transformers
{
    public static class CreateUserCommandFromResourceAssembler
    {
        public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
            new(resource.FirstName, resource.LastName, resource.Dni, resource.Phone, resource.DateOfBirth);
    }
}