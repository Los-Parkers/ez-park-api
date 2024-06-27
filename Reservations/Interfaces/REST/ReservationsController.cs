using ez_park_platform.Reservations.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Querys;
using ez_park_platform.Reservations.Domain.Services;
using ez_park_platform.Reservations.Interfaces.REST.Resources;
using ez_park_platform.Reservations.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ez_park_platform.Reservations.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ReservationsController(IBookingCommandService bookingCommandService, IBookingQueryService bookingQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateBooking([FromBody] CreateBookingResource resource)
        {
            try
            {
                var command = CreateBookingCommandFromResourceAssembler.ToCommandFromResource(resource);
                Booking? booking = await bookingCommandService.Handle(command);
                if (booking is null)
                {
                    return BadRequest("Failed to create booking.");
                }

                BookingResource bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
                return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, bookingResource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBookings()
        {
            IEnumerable<Booking> bookings = await bookingQueryService.Handle(new GetAllBookingsQuery());
            IEnumerable<BookingResource> bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(bookingResources);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetBookingById(int id)
        {
            Booking? booking = await bookingQueryService.Handle(new GetBookingByIdQuery(id));
            if (booking is null) return NotFound();
            BookingResource bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
            return Ok(bookingResource);
        }
        
        [HttpGet("userid/{userId}")]
        public async Task<ActionResult> GetBookingByUserId(int userId)
        {
            try
            {
                List<Booking> bookings = await bookingQueryService.Handle(new GetBookingsByUserIdQuery(userId));
                if (bookings == null || bookings.Count == 0)
                {
                    return NotFound($"No bookings found for user ID {userId}");
                }

                List<BookingResource> reviewResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity).ToList();
                return Ok(reviewResources);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("parkingid/{parkingId}")]
        public async Task<ActionResult> GetBookingByParkingId(int parkingId)
        {
            try
            {
                List<Booking> bookings = await bookingQueryService.Handle(new GetBookingsByParkingIdQuery(parkingId));
                if (bookings == null || bookings.Count == 0)
                {
                    return NotFound($"No bookings found for parking ID {parkingId}");
                }

                List<BookingResource> bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity).ToList();
                return Ok(bookingResources);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
