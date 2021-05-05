using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterialData.Repository_Pattern.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<ICollection<Author>> GetAll(QueryPaginationParameters queryPaginationParameters, string filter = null, string sort = null);
    }
}
