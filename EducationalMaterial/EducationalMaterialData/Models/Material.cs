using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MaterialType MaterialType { get; set; }
        public Author Authors { get; set; }
        public Review Reviews { get; set; }
    }
}
