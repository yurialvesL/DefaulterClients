using DefaulterClients.Application.DTOs.Request.User;
using DefaulterClients.Application.DTOs.Result.User;
using DefaulterClients.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaulterClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [Authorize]
        [HttpGet("Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var result = await _userService.GetUsers();

            if (result is null)
                return NotFound("Not found any users");

            return Ok(result);

        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserByIdResponse>> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Id is invalid");


            var task = await _userService.GetUserById(id);

            if (task is null)
                return NotFound("Task not found");

            return Ok(task);
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserResponse>> Put(Guid id, [FromBody] UserUpdateRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound("User not found");


            var userUpdated = await _userService.UpdateUser(user, userDTO);
            return Ok(userUpdated);

        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserResponse>> Delete(Guid id)
        {
            var result = await _userService.DeleteUserById(id);

            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }
    }
}
