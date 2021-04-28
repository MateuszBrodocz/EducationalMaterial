using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Repository_Pattern.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly EducationalMaterialDbContext _context;

        public Repository(EducationalMaterialDbContext context)
        {
            _context = context;
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            // Nothing
        }
    }
}
