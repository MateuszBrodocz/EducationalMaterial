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
                queryable = queryable.Where(Material => Material.Description.Contains(filter));
            }
            if (filter != null)
            {
                queryable = queryable.Where(Material => Material.Name.Contains(filter));
            }

            if (sort == "FirstName")
            {
                queryable = queryable.OrderBy(Material => Material.Url);
            }

            if (sort == "id")
            {
                queryable = queryable.OrderBy(Material => Material.AuthorId);
            }

            if (sort == "LastName")
            {
                queryable = queryable.OrderBy(Material => Material.Authors);
            }

            return await queryable
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
