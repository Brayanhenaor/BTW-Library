using System;
using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
	public class AuthorProfile: Profile
	{
		public AuthorProfile()
		{
			CreateMap<AuthorRequestDTO, Author>();
		}
	}
}

