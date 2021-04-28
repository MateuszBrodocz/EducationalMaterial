using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterialData.Repository_Pattern.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<ICollection<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
