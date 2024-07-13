using AutoMapper;
using Domain.DTO.Response;
using Domain.Entities;

namespace Application.Mapping
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanResponseDTO>()
                .ForMember(loanDto => loanDto.UserEmail,
                    loanMap => loanMap.MapFrom(loan => loan.User.Email))
                .ForMember(loanDto => loanDto.BookName,
                    loanMap => loanMap.MapFrom(loan => loan.Book.Title));
        }
    }
}

