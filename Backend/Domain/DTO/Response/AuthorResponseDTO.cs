using System;
namespace Domain.DTO.Response
{
	public class AuthorResponseDTO
	{
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public int BooksCount { get; set; }
    }
}

