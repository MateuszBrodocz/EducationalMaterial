using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Material> Material { get; set; }
    }
}
