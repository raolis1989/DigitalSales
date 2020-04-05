using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalSales.Entities.Sales
{
    public class DetailSale
    {
        public int iddetail_sale { get; set; }
        [Required]
        [ForeignKey("identry")]
        public int idsale { get; set; }
        [Required]
        public int idarticle { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Sale Sale { get; set; }
        public Article Article { get; set; }
    }
}
