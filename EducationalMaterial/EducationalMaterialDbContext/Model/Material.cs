using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialDbContext.Model
{
    public class Material
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MaterialType MaterialType { get; set; }
        public Author Authors { get; set; }
        public Review Reviews { get; set; }



}
}
