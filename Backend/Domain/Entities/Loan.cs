using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Loan : BaseEntity
	{
		public string UserId { get; set; }
		public Guid BookId { get; set; }
		public DateTime LoanDate { get; set; }
		public DateTime ReturnDate { get; set; }

		public User User { get; set; }
		public Book Book { get; set; }
	}
}

