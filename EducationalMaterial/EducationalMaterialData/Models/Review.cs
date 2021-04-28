using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Material Material { get; set; }

    }
}
