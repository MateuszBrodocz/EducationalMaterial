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
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(EducationalMaterialDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Material>> GetAll(string filter = null, string sort = null)
        {
            var queryable = _context.Set<Material>().AsQueryable();

            if (filter != null)
            {
                queryable = queryable.Where(material => material.Name.Contains(filter));
            }

            if (sort == "MaterialId")
            {
                queryable = queryable.OrderBy(material => material.MaterialId);
            }
            if (sort == "Name")
            {
                queryable = queryable.OrderBy(material => material.Name);
            }
            if (sort == "Reviews")
            {
                queryable = queryable.OrderBy(author => author.Reviews);
            }
            if (sort == "Url")
            {
                queryable = queryable.OrderBy(author => author.Url);
            }
            return await queryable
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
