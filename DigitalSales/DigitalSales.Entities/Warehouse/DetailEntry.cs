using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalSales.Entities.Warehouse
{
    public class DetailEntry
    {
        public int iddetail_entry { get; set; }
        [Required]
        [ForeignKey("identry")]
        public int identry { get; set; }
        [Required]
        public int idarticle { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Entry Entry { get; set; }
        //public Article Article { get; set; }
    }
}
