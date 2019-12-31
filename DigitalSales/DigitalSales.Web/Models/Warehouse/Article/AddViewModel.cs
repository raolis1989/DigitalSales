using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Warehouse.Article
{
    public class AddViewModel
    {

        [Required]
        public int IdCategory { get; set; }
        public string Code { get; set; }

        [StringLength(50, MinimumLength = 3,
           ErrorMessage = "El nombre no debe de tener mas de 50 caracteres, ni menos de  3 caracteres. ")]
        public string Name { get; set; }

        [Required]
        public decimal Price_Sale { get; set; }

        [Required]
        public int Stock { get; set; }
        public string Description { get; set; }
    }
}
