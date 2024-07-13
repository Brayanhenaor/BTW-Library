using System;
using Domain.Common.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
	public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public AuthorRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Set<Author>().ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Author>().FindAsync(id);
        }

        public async Task<Guid> CreateAsync(Author entity)
        {
            entity.Id = Guid.NewGuid(); 
            await _dbContext.Set<Author>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(Author entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Set<Author>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<Author>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

