﻿using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Shared.Domain.Repositories;

namespace ez_park_platform.Reservations.Domain.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {

    }
}
