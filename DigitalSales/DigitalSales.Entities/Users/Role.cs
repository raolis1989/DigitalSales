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
        [StringLength(256)]
        public string Description { get; set; }
        public bool Condition { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
