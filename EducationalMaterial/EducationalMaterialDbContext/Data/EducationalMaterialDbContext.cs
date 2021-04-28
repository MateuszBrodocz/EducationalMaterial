using EducationalMaterialDbContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialDbContext.Data
{
    public class EducationalMaterialDbContext : DbContext
    {
        public EducationalMaterialDbContext(DbContextOptions<EducationalMaterialDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
