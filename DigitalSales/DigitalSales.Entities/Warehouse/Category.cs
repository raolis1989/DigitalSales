using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalSales.Entities.Warehouse
{
    public class Category
    {
        public int IdCategory { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="El nombre no debe de tener mas de 50 caracteres, ni menos de 3 caracteres.")]
        public string Name { get; set; }
        
        [StringLength(256)]
        public string Description { get; set; }
        public bool Condition { get; set; }
        public ICollection<Article> Articles { get; set; }



    }
}
