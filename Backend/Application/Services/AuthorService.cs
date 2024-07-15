using Application.DTO.Request;
using AutoMapper;
using Domain.Common.Interfaces.Repositories;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AuthorResponseDTO>> GetAuthorsAsync()
        {
            return mapper.Map<IEnumerable<AuthorResponseDTO>>(await _authorRepository.GetAllAsync());
        }

        public async Task<AuthorResponseDTO> GetAuthorByIdAsync(Guid id)
        {
            return mapper.Map<AuthorResponseDTO>(await _authorRepository.GetByIdAsync(id));
        }

        public async Task<Guid> CreateAuthorAsync(AuthorRequestDTO author)
        {
            return await _authorRepository.CreateAsync(mapper.Map<Author>(author));
        }

        public async Task UpdateAuthorAsync(Guid id, AuthorRequestDTO author)
        {
            var entity = await _authorRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new AuthorNotFoundException();
            }

            mapper.Map(author, entity);

            await _authorRepository.UpdateAsync(entity);
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }
    }
}

