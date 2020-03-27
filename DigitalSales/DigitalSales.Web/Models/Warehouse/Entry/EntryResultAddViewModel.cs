using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Warehouse.Entry
{
    public class EntryResultAddViewModel
    {

        public int IdEntry { get; set; }
        public int IdProvider { get; set; }
        public int IdUser { get; set; }
        public string Type_Voucher { get; set; }
        public string Num_Voucher { get; set; }
        public DateTime Date_Time { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public List<DetailViewModel> detail_entry { get; set; }
    }
}
