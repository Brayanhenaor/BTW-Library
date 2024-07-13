using System;
using Domain.Entities;

namespace Domain.Common.Interfaces
{
	public interface IBookRepository
	{
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Guid> CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
    }
}

