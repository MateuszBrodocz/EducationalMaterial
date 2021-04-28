using AutoMapper;
using EducationalMaterialData.Dtos.MaterialDtos;
using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Profiles
{
    class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            // Source -> Target
            CreateMap<Material, MaterialReadDto>();
            CreateMap<MaterialCreateDto, Material>();
            CreateMap<MaterialUpdateDto, Material>();

        }
    }
}
