namespace Domain.Exceptions
{
	public class LoginInvalidException: BaseException
	{
        public LoginInvalidException() : base("User or email invalid", 401)
        {
        }
	}
}

