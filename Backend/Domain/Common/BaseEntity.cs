using System;
namespace Domain.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime DateAdded { get; set; }
	}
}

