using EducationalMaterialData.Data;
using EducationalMaterialData.Models;
using EducationalMaterialData.Repository_Pattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterialData.Repository_Pattern.Repository
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(EducationalMaterialDbContext context) : base(context)
        {
        }
        public async Task<ICollection<MaterialType>> GetAll(string filter = null, string sort = null)
        {

            var queryable = _context.Set<MaterialType>().AsQueryable();

            if (filter != null)
            {
                queryable = queryable.Where(MaterialType => MaterialType.Name.Contains(filter));
            }

            if (sort == "MaterialTypeId")
            {
                queryable = queryable.OrderBy(MaterialType => MaterialType.MaterialTypeId);
            }
            if (sort == "Name")
            {
                queryable = queryable.OrderBy(MaterialType => MaterialType.Name);
            }

            return await queryable
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
