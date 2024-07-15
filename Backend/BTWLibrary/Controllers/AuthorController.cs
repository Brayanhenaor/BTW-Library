using System;
using Application.DTO.Request;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Response;
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
        public async Task<IEnumerable<AuthorResponseDTO>> GetAuthors()
        {
            return await _authorService.GetAuthorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDTO>> GetAuthorById(Guid id)
        {
            return await _authorService.GetAuthorByIdAsync(id);
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

