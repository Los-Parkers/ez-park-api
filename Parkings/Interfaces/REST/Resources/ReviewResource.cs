﻿namespace ez_park_platform.Parkings.Interfaces.REST.Resources
{
    public record ReviewResource(int Id, string Description, int Rating, int ParkingId, int UserId);
}