using DigitalSales.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Sales
{
    public  class Sale
    {
        [Key]
        public int idsale { get; set; }
        [Required]
        public int idclient { get; set; }
        [Required]
        public int iduser { get; set; }

        [Required]
        public string type_voucher { get; set; }
        [Required]
        public string num_voucher { get; set; }
        [Required]
        public DateTime date_time { get; set; }
        [Required]
        public decimal tax { get; set; }
        [Required]
        public decimal total { get; set; }
        [Required]
        public string status { get; set; }
        public ICollection<DetailSale> detail_sale { get; set; }
        public Person Person { get; set; }

        public User User { get; set; }

        public string ProviderName => Person.Name;
        public string UserName => User.Name;

    }
}
