using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Users.User
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string TypeDocument { get; set; }
        public string NumDocument { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public bool Condition { get; set; }

        public string RoleName { get; set; }
    }
}
