using HomeBookerAPI.Models;
using HomeBookerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookerAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserRequest userRequest)
        {
            User user = new User()
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password
            };

            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser([FromQuery] Guid id, UserRequest userRequest)
        {
            var user = await _userService.GetUserByIdAsync(id);

            user.Name = userRequest.Name;
            user.Email = userRequest.Email;
            user.Password = userRequest.Password;

            await _userService.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
            await _userService.DeleteUserAsync(id);

            return NoContent();
        }
    }

}
