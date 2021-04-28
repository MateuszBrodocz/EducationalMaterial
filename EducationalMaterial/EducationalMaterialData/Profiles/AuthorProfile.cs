using AutoMapper;
using EducationalMaterialData.Dtos.AuthorDtos;
using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Profiles
{
    class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            // Source -> Target
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();

        }
    }
}
