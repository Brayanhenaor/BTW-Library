using System;
using System.Net;

namespace Domain.Exceptions
{
	public class BaseException: Exception
	{
        public BaseException(string message, int httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public int HttpStatusCode { get; }
    }
}

