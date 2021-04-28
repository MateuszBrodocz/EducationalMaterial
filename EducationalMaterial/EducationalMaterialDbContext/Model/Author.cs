using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialDbContext.Model
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Material> Material { get; set; }
    }
}
