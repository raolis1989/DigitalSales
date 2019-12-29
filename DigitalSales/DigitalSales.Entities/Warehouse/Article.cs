using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Entities.Warehouse
{
    public class Article
    {
        public int idArcticle { get; set; }
        public int idCategory { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price_Sale { get; set; }
        public int Stock { get; set; }
        public bool Condition { get; set; }
        public Category Category { get; set; }
    }
}
