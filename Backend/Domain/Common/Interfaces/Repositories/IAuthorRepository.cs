using System;
using Domain.Entities;

namespace Domain.Common.Interfaces.Repositories
{
	public interface IAuthorRepository
	{
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Author book);
        Task UpdateAsync(Author book);
        Task DeleteAsync(Guid id);
    }
}

