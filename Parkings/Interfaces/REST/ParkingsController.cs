using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;
using ez_park_platform.Parkings.Domain.Services;
using ez_park_platform.Parkings.Interfaces.REST.Resources;
using ez_park_platform.Parkings.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ez_park_platform.Parkings.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ParkingsController(
            IParkingCommandService parkingCommandService,
            IParkingQueryService parkingQueryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateParking([FromBody] CreateParkingResource resource)
        {
            try
            {
                var command = CreateParkingCommandFromResourceAssembler.ToCommandFromResource(resource);
                Parking? parking = await parkingCommandService.Handle(command);
                if (parking is null)
                {
                    return BadRequest("Failed to create parking.");
                }

                ParkingResource parkingResource = ParkingResourceFromEntityAssembler.ToResourceFromEntity(parking);
                return CreatedAtAction(nameof(GetParkingById), new { id = parking.Id }, parkingResource);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllParkings()
        {
            IEnumerable<Parking> parkings = await parkingQueryService.Handle(new GetAllParkingsQuery());
            IEnumerable<ParkingResource> parkingResource =
                parkings.Select(ParkingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(parkingResource);
        }

        [HttpGet("userid/{userId}")]
        public async Task<ActionResult> GetParkingByUserId(int userId)
        {
            try
            {
                List<Parking> parkings = await parkingQueryService.Handle(new GetParkingsByUserIdQuery(userId));
                if (parkings == null || parkings.Count == 0)
                {
                    return NotFound($"No parkings found for user ID {userId}");
                }

                List<ParkingResource> parkingResources = parkings.Select(ParkingResourceFromEntityAssembler.ToResourceFromEntity).ToList();
                return Ok(parkingResources);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


    [HttpGet("{id:int}")]
        public async Task<ActionResult> GetParkingById(int id)
        {
            Parking? parking = await parkingQueryService.Handle(new GetParkingByIdQuery(id));
            if (parking is null) return NotFound();

            ParkingResource parkingResource = ParkingResourceFromEntityAssembler.ToResourceFromEntity(parking);
            return Ok(parkingResource);
        }
    }
}
