using System;
using Application.Services;
using Domain.Common.Interfaces.Services;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BTWLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IEnumerable<LoanResponseDTO>> GetLoans()
        {
            return await _loanService.GetAllLoans();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanResponseDTO>> GetLoan(Guid id)
        {
            return await _loanService.GetLoanById(id);
        }

        [HttpPost("reserve/{bookId}")]
        public async Task<ActionResult> ReserveBook(Guid bookId)
        {
            var userIdClaim = User.FindFirst("id");

            var userId = userIdClaim.Value;

            var reservationId = await _loanService.ReserveBook(userId, bookId);

            return Ok(new { ReservationId = reservationId });
        }

        [HttpDelete("cancel/{id}")]
        public async Task CancelReservation(Guid id)
        {
            await _loanService.CancelReservation(id);
        }

        [HttpGet("my-reservations")]
        public async Task<IEnumerable<LoanResponseDTO>> GetMyReservations()
        {
            var userIdClaim = User.FindFirst("id");

            var userId = userIdClaim.Value;

            return await _loanService.GetMyReservations(userId);
        }

    }
}

