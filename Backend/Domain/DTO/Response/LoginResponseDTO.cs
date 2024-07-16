
namespace Domain.DTO.Response
{
	public class LoginResponseDTO
	{
		public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public LoginResponseDTO(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
	}
}

