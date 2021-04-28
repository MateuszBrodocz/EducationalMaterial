using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Material> Material { get; set; }
    }
}
