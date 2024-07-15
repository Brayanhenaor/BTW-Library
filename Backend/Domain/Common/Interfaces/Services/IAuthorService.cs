using Application.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Common.Interfaces.Services
{
	public interface IAuthorService
	{
        Task<IEnumerable<AuthorResponseDTO>> GetAuthorsAsync();
        Task<AuthorResponseDTO> GetAuthorByIdAsync(Guid id);
        Task<Guid> CreateAuthorAsync(AuthorRequestDTO author);
        Task UpdateAuthorAsync(Guid id, AuthorRequestDTO author);
        Task DeleteAuthorAsync(Guid id);
    }
}

