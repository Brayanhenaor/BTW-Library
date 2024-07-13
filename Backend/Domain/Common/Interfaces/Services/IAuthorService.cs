using System;
using Application.DTO.Request;
using Domain.Entities;

namespace Domain.Common.Interfaces.Services
{
	public interface IAuthorService
	{
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid id);
        Task<Guid> CreateAuthorAsync(AuthorRequestDTO author);
        Task UpdateAuthorAsync(Guid id, AuthorRequestDTO author);
        Task DeleteAuthorAsync(Guid id);
    }
}

