using DigitalSales.Web.Models.Warehouse.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Warehouse.Article
{
    public class ArticleViewModel
    {
        public int IdArticle { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price_Sale { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public bool Condition { get; set; }
    }
}
