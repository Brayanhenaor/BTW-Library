using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Interfaces
{
	public interface IApplicationDBContext
	{
		DbSet<Book> Books { get; set; }
		DbSet<Author> Authors { get; set; }
		DbSet<Loan> Loans { get; set; }
	}
}

