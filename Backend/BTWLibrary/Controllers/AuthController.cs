using Domain.Common.Interfaces.Services;
using Domain.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace BTWLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterRequest model)
        {
            await authenticationService.RegisterAsync(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var token = await authenticationService.LoginAsync(model);

            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}

