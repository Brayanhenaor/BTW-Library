using System;
namespace Domain.Exceptions
{
    public class BookNotAvailableException : BaseException
    {
        public BookNotAvailableException() : base("The book is not available", 400)
        {
        }
    }
}

