using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Querys;
using ez_park_platform.Users.Domain.Services;
using ez_park_platform.Users.Interfaces.REST.Resources;
using ez_park_platform.Users.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ez_park_platform.Users.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController(
        IUserCommandService userCommandService,
        IUserQueryService userQueryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserResource resource)
        {
            User? user = await userCommandService.Handle(CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource));
            if (user is null) return BadRequest();

            UserResource userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userResource);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await userQueryService.Handle(new GetAllUsersQuery());
            IEnumerable<UserResource> userResource = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(userResource);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            User? user = await userQueryService.Handle(new GetUserByIdQuery(id));
            if (user is null) return NotFound();

            UserResource userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return Ok(userResource);
        }
    }
}
