using AutoMapper;
using Domain.Common.Interfaces.Repositories;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Response;
using Domain.Exceptions;

namespace Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository loanRepository;
        private readonly IMapper mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            this.loanRepository = loanRepository;
            this.mapper = mapper;
        }

        public async Task CancelReservation(Guid reservationId)
        {
            var loan = await loanRepository.GetLoanById(reservationId);

            if (loan == null)
                throw new LoanNotFoundException();

            await loanRepository.CancelReservation(loan);
        }

        public async Task<IEnumerable<LoanResponseDTO>> GetAllLoans()
        {
            var reservations = await loanRepository.GetAllLoans();
            return mapper.Map<List<LoanResponseDTO>>(reservations);
        }

        public async Task<LoanResponseDTO> GetLoanById(Guid id)
        {
            var loan = await loanRepository.GetLoanById(id);

            if (loan == null)
                throw new LoanNotFoundException();

            return mapper.Map<LoanResponseDTO>(loan);
        }

        public async Task<Guid> ReserveBook(string userId, Guid bookId)
        {
            return await loanRepository.ReserveBook(userId, bookId);
        }
    }
}

