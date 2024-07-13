using System;
using Domain.DTO.Response;
using Domain.Entities;

namespace Domain.Common.Interfaces.Repositories
{
	public interface ILoanRepository
	{
        Task CancelReservation(Loan loan);
        Task<IEnumerable<Loan>> GetAllLoans();
        Task<Loan> GetLoanById(Guid id);
        Task<Guid> ReserveBook(string userId, Guid bookId);
    }
}

