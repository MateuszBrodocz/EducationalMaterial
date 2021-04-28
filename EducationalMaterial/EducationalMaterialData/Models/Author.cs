using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationalMaterialData.Models
{
    public class Author
    {
        [Required]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(30, ErrorMessage = "FirstName can't be more than 30.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(30, ErrorMessage = "FirstName can't be more than 30.")]
        public string LastName { get; set; }

        public ICollection<Material> Material { get; set; }
    }
}
