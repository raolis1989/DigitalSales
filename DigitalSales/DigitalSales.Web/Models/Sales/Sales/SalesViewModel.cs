using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Sales.Sales
{
    public class SalesViewModel
    {
        public int IdSale { get; set; }
        public int IdProvider { get; set; }
        public int IdUser { get; set; }
        public string Type_Voucher { get; set; }
        public string Num_Voucher { get; set; }
        public DateTime Date_Time { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string numDocument { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public List<DetailSaleViewModel> detail_sale { get; set; }
    }
}
