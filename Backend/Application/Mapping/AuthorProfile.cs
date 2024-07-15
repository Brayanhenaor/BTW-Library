using System;
using Application.DTO.Request;
using AutoMapper;
using Domain.DTO.Response;
using Domain.Entities;

namespace Application.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequestDTO, Author>();
            CreateMap<Author, AuthorResponseDTO>()
                .ForMember(loanDto => loanDto.BooksCount,
                    loanMap => loanMap.MapFrom(loan => loan.Books.Count()));
        }
    }
}

