using EducationalMaterialData.Data;
using EducationalMaterialData.Repository_Pattern.Interfaces;
using EducationalMaterialData.Repository_Pattern.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterialData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationalMaterialDbContext _context;

        public UnitOfWork(EducationalMaterialDbContext context)
        {
            _context = context;
            Author = new AuthorRepository(_context);
            Material = new MaterialRepository(_context);
            MaterialType = new MaterialTypeRepository(_context);
            Review = new ReviewRepository(_context);
        }

        public IAuthorRepository Author { get; private set; }
        public IMaterialRepository Material { get; private set; }
        public IMaterialTypeRepository MaterialType { get; private set; }
        public IReviewRepository Review { get; private set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
