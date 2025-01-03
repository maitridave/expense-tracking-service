using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/SignIn
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel model)
        {
            var result = await _authService.SignInAsync(model.Email, model.Password, model.RememberMe);

            if (result)
            {
                return Ok();
            }

            return Unauthorized();
        }

        // POST: api/Auth/SignUp
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var result = await _authService.SignUpAsync(model.Name, model.Email, model.Password);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
