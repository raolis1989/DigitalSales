using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Sales.Sales
{
    public class DetailSaleViewModel
    {
        [Required]
        public int idArticle { get; set; }

        public string Article { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
