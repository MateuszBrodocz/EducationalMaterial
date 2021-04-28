using AutoMapper;
using EducationalMaterialData.Dtos.ReviewDtos;
using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            // Source -> Target
            CreateMap<Review, ReviewReadDto>();
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();

        }
    }
}
