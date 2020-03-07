using DigitalSales.Entities.Sales;
using DigitalSales.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Warehouse
{
    public class Entry
    {
        public int IdEntry { get; set; }
        [Required]
        public int idprovider { get; set; }
        [Required]
        public int iduser { get; set; }

        [Required]
        public string Type_Voucher { get; set; }
        [Required]
        public string Num_Voucher { get; set; }
        [Required]
        public DateTime Date_Time { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public string Status { get; set; }
        public ICollection<DetailEntry> Details { get; set; }
        public Person Person { get; set; }

        public User User { get; set; }

        public string ProviderName => Person.Name;
    //    public string UserName => User.Name;

    }
}
