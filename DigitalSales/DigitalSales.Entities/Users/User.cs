using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Users
{
    public class User
    {
        public int idUser { get; set; }
        [Required]
        public int idRol { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="El nombre no tiene el maximo numero de caracteres")]
        public string  name { get; set; }
        public string typeDocument { get; set; }
        public string numDocument { get; set; }
        public string Address { get; set; }
        public string  Phone { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public byte[] PasswordHash { get; set; }
        
        [Required]
        public byte[] PasswordSalt { get; set; }
        public bool Condition { get; set; }

        public Role  rol { get; set; }

    }
}
