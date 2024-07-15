using System;
using AutoMapper;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Application.Mapping
{
	public class BookProfile: Profile
    {
		public BookProfile()
		{
			CreateMap<BookRequestDTO, Book>();
			CreateMap<Book, BookResponseDTO>();
		}
	}
}

