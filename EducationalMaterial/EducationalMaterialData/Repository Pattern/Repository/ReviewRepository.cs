using EducationalMaterialData.Data;
using EducationalMaterialData.Models;
using EducationalMaterialData.Repository_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Repository_Pattern.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(EducationalMaterialDbContext context) : base(context)
        {
        }
    }
}
