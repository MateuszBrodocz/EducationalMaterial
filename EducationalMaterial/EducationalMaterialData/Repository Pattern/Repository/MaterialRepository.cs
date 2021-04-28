using EducationalMaterialData.Data;
using EducationalMaterialData.Models;
using EducationalMaterialData.Repository_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Repository_Pattern.Repository
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(EducationalMaterialDbContext context) : base(context)
        {
        }
    }
}
