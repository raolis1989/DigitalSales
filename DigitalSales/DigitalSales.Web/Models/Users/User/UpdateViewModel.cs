using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Users.User
{
    public class UpdateViewModel
    {

        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdRole { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener mas de 100 caracteres")]
        public string Name { get; set; }
        public string TypeDocument { get; set; }
        public string NumDocument { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }


        public string Password { get; set; }

        public bool ActPassword { get; set; }
    }
}
