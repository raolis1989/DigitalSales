using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Users
{
    public class Role
    {
        public int idRole { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
