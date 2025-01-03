using Microsoft.AspNetCore.Mvc;
using my_expense_tracker.Models;
using my_expense_tracker.Services;
using System.Threading.Tasks;

namespace my_expense_tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            await _userService.RegisterUserAsync(user, null);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] User user)
        {
            var authenticatedUser = await _userService.AuthenticateUserAsync(user.Username, user.PasswordHash);
            if (authenticatedUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(authenticatedUser);
        }
    }
}