using System;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTWLibrary.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook(BookRequestDTO book)
        {
            var createdBookId = await _bookService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBookId }, createdBookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, BookRequestDTO book)
        {
            await _bookService.UpdateBookAsync(id, book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

