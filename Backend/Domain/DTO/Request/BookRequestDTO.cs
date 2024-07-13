namespace Domain.DTO.Request
{
	public class BookRequestDTO
	{
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsAvailable { get; set; }
    }
}

