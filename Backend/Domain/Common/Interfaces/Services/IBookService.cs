using System;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Domain.Common.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDTO>> GetBooksAsync();
        Task<BookResponseDTO> GetBookByIdAsync(Guid id);
        Task<Guid> CreateBookAsync(BookRequestDTO book);
        Task UpdateBookAsync(Guid id, BookRequestDTO book);
        Task DeleteBookAsync(Guid id);
    }
}

