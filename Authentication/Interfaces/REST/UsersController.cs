using ez_park_platform.Authentication.Domain.Model.Commands;
using ez_park_platform.Authentication.Domain.Model.Aggregates;
using ez_park_platform.Authentication.Domain.Model.Commands;
using ez_park_platform.Authentication.Domain.Model.Querys;
using ez_park_platform.Authentication.Domain.Repositories;
using ez_park_platform.Authentication.Domain.Services;
using ez_park_platform.Authentication.Interfaces.REST.Resources;
using ez_park_platform.Authentication.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ez_park_platform.Authentication.Interfaces.REST
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

        [HttpGet("dni/{dni}")]
        public async Task<ActionResult> GetUserByDni(string dni)
        {
            User? user = await userQueryService.Handle(new GetUserByDniQuery(dni));
            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            User? user = await userQueryService.Handle(new GetUserByIdQuery(id));
            if (user is null) return NotFound();

            UserResource userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return Ok(userResource);
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetUserByEmailAndPassword([FromBody] LoginResource resource)
        {
            User? user = await userQueryService.Handle(new GetUserByEmailAndPassword(resource.Email, resource.Password));
            if (user is null) return NotFound();

            UserResource userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return Ok(userResource);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool deleted = await userCommandService.Handle(new DeleteUserCommand(id));

            if (!deleted) return NotFound();

            return Ok();
        }
    }
}
