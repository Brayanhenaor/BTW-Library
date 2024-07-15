using System;
namespace Domain.Exceptions
{
    public class AuthorNotFoundException : BaseException
    {
        public AuthorNotFoundException() : base("Author not found", 404)
        {
        }
    }
}

