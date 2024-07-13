using System;
using Application.DTO.Request;
using AutoMapper;
using Domain.Common.Interfaces.Repositories;
using Domain.Common.Interfaces.Services;
using Domain.Entities;

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

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return await _authorRepository.GetByIdAsync(id);
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
                throw new ArgumentException($"Author with id {id} not found");
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

