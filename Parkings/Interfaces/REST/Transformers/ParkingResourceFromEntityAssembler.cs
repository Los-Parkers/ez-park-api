﻿using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Interfaces.REST.Resources;

namespace ez_park_platform.Parkings.Interfaces.REST.Transformers
{
    public static class ParkingResourceFromEntityAssembler
    {
        public static ParkingResource ToResourceFromEntity(Parking entity)
            => new(entity.Id, entity.Address, entity.Width, entity.Length, entity.Height, entity.Price, entity.Phone, entity.Description, entity.UserId);
    }
}