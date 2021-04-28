using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public int MaterialTypeId { get; set; }
        public int AuthorId { get; set; }

        public MaterialType MaterialType { get; set; }
        public Author Authors { get; set; }
        public ICollection<Review> Reviews{ get; set; }
    }
}
