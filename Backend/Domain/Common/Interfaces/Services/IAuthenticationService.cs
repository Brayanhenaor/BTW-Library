using System;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Microsoft.AspNetCore.Identity;

namespace Domain.Common.Interfaces.Services
{
	public interface IAuthenticationService
	{
        Task<IdentityResult> RegisterAsync(RegisterRequest model);
        Task<LoginResponseDTO> LoginAsync(LoginRequest model);
    }
}

