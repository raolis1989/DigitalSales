using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Warehouse.Entry
{
    public class AddEntryViewModel
    {

        [Required]
        public int IdProvider { get; set; }
        [Required]
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
        public List <DetailViewModel> Details { get; set; }

    }
}
