using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Sales.Sales
{
    public class AddSaleViewModel
    {
        [Required]
        public int idClient { get; set; }

        public int IdUser { get; set; }
        [Required]
        public string Type_Voucher { get; set; }
        [Required]
        public string Num_Voucher { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }

        [Required]
        public List<DetailSaleViewModel> detail_sale { get; set; }

    }
}
