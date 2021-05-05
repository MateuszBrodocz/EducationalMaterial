using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Dtos.ReviewDtos
{
    public class ReviewReadDto
    {
        public int ReviewId { get; set; }
        public string Description { get; set; }
        public int MaterialId { get; set; }

    }
}
