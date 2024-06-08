using ez_park_platform.EzPark.Application.Domain.Model.Commands;
using ez_park_platform.EzPark.Application.Domain.Model.Querys;
using ez_park_platform.EzPark.Application.Domain.Services;
using ez_park_platform.EzPark.Application.Interfaces.REST.Resources;
using ez_park_platform.EzPark.Application.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ez_park_platform.EzPark.Application
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserSourcesController(
        IUserSourceCommandService userSourceCommandService,
        IUserSourceQueryService userSourceQueryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUserSource([FromBody] CreateUserSourceResource resource)
        {
            var createUserSourceCommand = CreateUserSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await userSourceCommandService.Handle(createUserSourceCommand);

            if (result is null) return BadRequest();

            return CreatedAtAction(
                nameof(GetUserSourceById), 
                new { id = result.Id }, 
                UserSourceResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserSourceById(int id)
        {
            var getUserSourceByIdQuery = new GetUserSourceByIdQuery(id);
            var result = await userSourceQueryService.Handle(getUserSourceByIdQuery);

            if (result is null) return NotFound();

            var resource = UserSourceResourceFromEntityAssembler.ToResourceFromEntity(result);

            return Ok(resource);
        }
    }
}
