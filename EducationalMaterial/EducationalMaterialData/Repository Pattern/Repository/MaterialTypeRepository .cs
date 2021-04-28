using EducationalMaterialData.Data;
using EducationalMaterialData.Models;
using EducationalMaterialData.Repository_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Repository_Pattern.Repository
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(EducationalMaterialDbContext context) : base(context)
        {
        }
    }
}
