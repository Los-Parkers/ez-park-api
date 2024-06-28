using ez_park_platform.Authentication.Domain.Model.Commands;
using ez_park_platform.Authentication.Interfaces.REST.Resources;

namespace ez_park_platform.Authentication.Interfaces.REST.Transformers
{
    public static class CreateUserCommandFromResourceAssembler
    {
        public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
            new(resource.Email, resource.Password, resource.FirstName, resource.LastName, resource.Dni, resource.Phone, resource.DateOfBirth);
    }
}