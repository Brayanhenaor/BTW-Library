using System;
using Domain.DTO.Response;

namespace Domain.Common.Interfaces.Services
{
	public interface ILoanService
	{
		Task<IEnumerable<LoanResponseDTO>> GetAllLoans();
		Task<IEnumerable<LoanResponseDTO>> GetMyReservations(string userId);
        Task<LoanResponseDTO> GetLoanById(Guid id);
		Task<Guid> ReserveBook(string userId, Guid bookId);
		Task CancelReservation(Guid reservationId);
    }
}

