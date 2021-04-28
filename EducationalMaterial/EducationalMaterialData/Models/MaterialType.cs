using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EducationalMaterialData.Models
{
    [Table("MaterialType")]
    public class MaterialType
    {
        [Required]
        public int MaterialTypeId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30, ErrorMessage = "FirstName can't be more than 30.")]
        public string Name { get; set; }

        public ICollection<Material> Material { get; set; }
    }
}
