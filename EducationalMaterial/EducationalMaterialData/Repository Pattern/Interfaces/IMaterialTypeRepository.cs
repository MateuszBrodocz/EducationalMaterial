using EducationalMaterialData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterialData.Repository_Pattern.Interfaces
{
    public interface IMaterialTypeRepository : IRepository<MaterialType>
    {
         Task<ICollection<MaterialType>> GetAll(string filter = null, string sort = null);
    }
}
