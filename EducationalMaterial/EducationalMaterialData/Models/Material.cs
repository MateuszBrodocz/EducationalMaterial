using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EducationalMaterialData.Models
{
    [Table("Material")]
    public class Material
    {
        [Required]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Url is Required")]
        public string Url { get; set; }

        [ForeignKey ("Material")]
        public int MaterialTypeId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public MaterialType MaterialType { get; set; }

        public Author Authors { get; set; }

        public ICollection<Review> Reviews{ get; set; }
    }
}
