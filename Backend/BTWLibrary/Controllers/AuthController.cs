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
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var result = await authenticationService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return Ok(new { Result = "User created successfully" });
            }

            return BadRequest(result.Errors);
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

