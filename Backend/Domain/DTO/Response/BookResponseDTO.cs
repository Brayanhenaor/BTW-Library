using System;
using Domain.Entities;

namespace Domain.DTO.Response
{
	public class BookResponseDTO
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsAvailable { get; set; }

        public AuthorResponseDTO Author { get; set; }
    }
}

