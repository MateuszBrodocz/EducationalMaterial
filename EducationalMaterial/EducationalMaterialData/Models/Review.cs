using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EducationalMaterialData.Models
{
    
    public class Review
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Name Description can't be more than 200")]
        public string Description { get; set; }

        [ForeignKey ("Material")]
        public int MaterialId { get; set; }

        public Material Material { get; set; }

    }
}
