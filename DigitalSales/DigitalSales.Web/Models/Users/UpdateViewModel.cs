using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Users
{
    public class UpdateViewModel
    {
        [Required]
        public int IdRole { get; set; }

        [Required]
        public string Name { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
