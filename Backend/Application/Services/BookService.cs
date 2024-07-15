using System;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookResponseDTO>> GetBooksAsync()
        {
            return mapper.Map<IEnumerable<BookResponseDTO>>(await _bookRepository.GetBooksAsync());
        }

        public async Task<BookResponseDTO> GetBookByIdAsync(Guid id)
        {
            return mapper.Map<BookResponseDTO>(await _bookRepository.GetBookByIdAsync(id));
        }

        public async Task<Guid> CreateBookAsync(BookRequestDTO book)
        {
            return await _bookRepository.CreateBookAsync(mapper.Map<Book>(book));
        }

        public async Task UpdateBookAsync(Guid id, BookRequestDTO book)
        {
            var entity = await _bookRepository.GetBookByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Book with id {id} not found");
            }

            mapper.Map(book, entity);


            await _bookRepository.UpdateBookAsync(entity);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}

