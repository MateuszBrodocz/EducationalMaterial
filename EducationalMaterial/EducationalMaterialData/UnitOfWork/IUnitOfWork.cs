using EducationalMaterialData.Repository_Pattern.Interfaces;
using System.Threading.Tasks;

namespace EducationalMaterialData.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAuthorRepository Author { get; }
        public IMaterialRepository Material { get; }
        public IMaterialTypeRepository MaterialType { get; }
        public IReviewRepository Review { get;}
        Task Save();
    }
}

