using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Users
{
    public class RoleViewModel
    {
        public int idRole { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Condition { get; set; }
    }
}
