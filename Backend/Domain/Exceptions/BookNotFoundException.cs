using System;
namespace Domain.Exceptions
{
    public class BookNotFoundException : BaseException
    {
        public BookNotFoundException(string message) : base(message, 404)
        {
        }
    }
}

