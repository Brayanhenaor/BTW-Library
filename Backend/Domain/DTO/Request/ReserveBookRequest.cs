using System;
namespace Domain.DTO.Request
{
	public class ReserveBookRequest
	{
		public string UserId { get; set; }

        public ReserveBookRequest(string userId, Guid bookId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; set; }
	}
}

