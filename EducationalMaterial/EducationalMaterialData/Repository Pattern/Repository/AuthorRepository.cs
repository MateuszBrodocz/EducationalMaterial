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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(EducationalMaterialDbContext context) : base(context)
        { 
        }
        public async Task<ICollection<Author>> GetAll(string filter = null, string sort = null)
        {

            var queryable = _context.Set<Author>().AsQueryable();

            if (filter != null)
            {
                queryable = queryable.Where(Author => Author.FirstName.Contains(filter));
            }
            if (filter != null)
            {
                queryable = queryable.Where(Author => Author.LastName.Contains(filter));
            }

            if (sort == "FirstName")
            {
                queryable = queryable.OrderBy(Author => Author.FirstName);
            }

            if (sort == "id")
            {
                queryable = queryable.OrderBy(Author => Author.AuthorId);
            }

            if (sort == "LastName")
            {
                queryable = queryable.OrderBy(Author => Author.LastName);
            }

            return await queryable
                .AsNoTracking()
                .ToListAsync();
        }
        
    }
}
