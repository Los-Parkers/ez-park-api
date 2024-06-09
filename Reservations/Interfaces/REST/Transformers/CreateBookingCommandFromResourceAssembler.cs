using ez_park_platform.Reservations.Domain.Model.Commands;
using ez_park_platform.Reservations.Interfaces.REST.Resources;

namespace ez_park_platform.Reservations.Interfaces.REST.Transformers
{
    public static class CreateBookingCommandFromResourceAssembler
    {
        public static CreateBookingCommand ToCommandFromResource(CreateBookingResource resource) =>
            new(resource.HoursRegistered, resource.TotalPrice, resource.StartHour, resource.EndHour);
    }
}