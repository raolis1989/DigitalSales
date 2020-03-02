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
        public int IdProvider { get; set; }
        [Required]
        public int IdUser { get; set; }

        [Required]
        public string TypeVoucher { get; set; }
        public string SerialVoucher { get; set; }
        [Required]
        public string NumVoucher { get; set; }
        [Required]
        public DateTime DateHour { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public string Status { get; set; }
        public ICollection<DetailEntry> Details { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }

    }
}
