using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Author : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Document { get; set; }
	}
}

