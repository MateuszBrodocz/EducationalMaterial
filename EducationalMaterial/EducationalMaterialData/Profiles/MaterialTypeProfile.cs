using AutoMapper;
using EducationalMaterialData.Dtos.MaterialTypeDtos;
using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Profiles
{
    class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            // Source -> Target
            CreateMap<MaterialType, MaterialTypeReadDto>();
            CreateMap<MaterialTypeCreateDto, MaterialType>();
            CreateMap<MaterialTypeUpdateDto, MaterialType>();

        }
    }
}
