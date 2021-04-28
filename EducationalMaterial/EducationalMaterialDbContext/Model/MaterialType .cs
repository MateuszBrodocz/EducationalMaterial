using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialDbContext.Model
{
    public  class MaterialType
    {
        public string Name { get; set; }
        public ICollection<Material> Material { get; set; }
    }
}
