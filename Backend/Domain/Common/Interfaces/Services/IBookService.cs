using System;
using Domain.DTO.Request;
using Domain.Entities;

namespace Domain.Common.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Guid> CreateBookAsync(BookRequestDTO book);
        Task UpdateBookAsync(Guid id, BookRequestDTO book);
        Task DeleteBookAsync(Guid id);
    }
}

