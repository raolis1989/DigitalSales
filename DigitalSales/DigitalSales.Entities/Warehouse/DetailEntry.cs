using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Warehouse
{
    public class DetailEntry
    {
        public int IdDtailEntry { get; set; }
        [Required]
        public int IdEntry { get; set; }
        [Required]
        public int IdArticle { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Entry Entry { get; set; }
    }
}
