using Microsoft.AspNetCore.Mvc;
using MyPrivateDrive.API.DTOs;
using MyPrivateDrive.API.Services;

namespace MyPrivateDrive.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request);
            if (token == null)
                return Unauthorized();
            return Ok(new { token });
        }
    }
}
