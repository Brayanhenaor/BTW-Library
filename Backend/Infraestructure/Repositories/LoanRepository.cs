using System;
using Domain.Common.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDBContext context;

        public LoanRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task CancelReservation(Loan loan)
        {
            context.Loans.Remove(loan);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loan>> GetAllLoans()
        {
            return await context.Loans.Include(loan => loan.User).Include(loan => loan.Book).ToListAsync();
        }

        public async Task<Loan> GetLoanById(Guid id)
        {
            return await context.Loans.Include(loan => loan.User).Include(loan => loan.Book).FirstOrDefaultAsync(loan => loan.Id == id);
        }

        public async Task<Guid> ReserveBook(string userId, Guid bookId)
        {
            var loan = new Loan
            {
                BookId = bookId,
                UserId = userId,
                LoanDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddDays(10)
            };

            await context.Loans.AddAsync(loan);
            await context.SaveChangesAsync();

            return loan.Id;
        }
    }
}

