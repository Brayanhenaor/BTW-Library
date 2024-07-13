using System;
namespace Domain.DTO.Response
{
	public class LoginResponse
	{
		public string Token { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}

