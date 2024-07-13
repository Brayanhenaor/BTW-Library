using System;
using Application.DTO.Request;
using Domain.Common.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTWLibrary.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(Guid id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAuthor(AuthorRequestDTO author)
        {
            var createdAuthorId = await _authorService.CreateAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthorId }, createdAuthorId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, AuthorRequestDTO author)
        {
            await _authorService.UpdateAuthorAsync(id, author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}

