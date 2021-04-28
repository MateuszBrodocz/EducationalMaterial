﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Dtos.MaterialDtos
{
    public class MaterialCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int MaterialTypeId { get; set; }
        public int AuthorId { get; set; }
    }
}
