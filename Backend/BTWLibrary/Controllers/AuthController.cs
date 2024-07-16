using Domain.Common.Interfaces.Services;
using Domain.DTO.Request;
using Domain.DTO.Response;
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
        public async Task Register(RegisterRequest model)
        {
            await authenticationService.RegisterAsync(model);
        }

        [HttpPost("login")]
        public async Task<LoginResponseDTO> Login(LoginRequest model)
        {
            return await authenticationService.LoginAsync(model);
        }
    }
}

