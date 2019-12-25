using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Warehouse.Category
{
    public class CategoryViewModel
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Condition { get; set; }
    }
}
