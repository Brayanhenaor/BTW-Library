using System;
using Domain.DTO.Request;
using Microsoft.AspNetCore.Identity;

namespace Domain.Common.Interfaces.Services
{
	public interface IAuthenticationService
	{
        Task<IdentityResult> RegisterAsync(RegisterRequest model);
        Task<string> LoginAsync(LoginRequest model);
    }
}

