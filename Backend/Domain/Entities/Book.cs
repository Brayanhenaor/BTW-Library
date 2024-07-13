using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Book: BaseEntity
	{
		public string Title { get; set; }
		public DateTime PublishedDate { get; set; }
		public Guid AuthorId { get; set; }
		public bool IsAvailable { get; set; }

        public Author Author { get; set; }
    }
}

