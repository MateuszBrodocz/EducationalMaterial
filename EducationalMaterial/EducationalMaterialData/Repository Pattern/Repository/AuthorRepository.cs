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
        public async Task<ICollection<Author>> GetAll(QueryPaginationParameters queryPaginationParameters, string filter = null, string sort = null)
        {
            var queryable = _context.Set<Author>().AsQueryable();

            if (filter != null)
            {
                queryable = queryable.Where(author => author.FirstName.Contains(filter));
            }

            if (sort == "authorId")
            {
                queryable = queryable.OrderBy(author => author.AuthorId);
            }
            if (sort == "lastName")
            {
                queryable = queryable.OrderBy(author => author.LastName);
            }
            if (sort == "material")
            {
                queryable = queryable.OrderBy(author => author.Material);
            }
            return await queryable
                .Skip((queryPaginationParameters.PageNumber - 1) * queryPaginationParameters.PageSize)
                .Take(queryPaginationParameters.PageSize)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
