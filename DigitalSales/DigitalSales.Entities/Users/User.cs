using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalSales.Entities.Users
{
    public class User
    {
        public int IdUser { get; set; }
        [Required]
        public int IdRol { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="El nombre no tiene el maximo numero de caracteres")]
        public string  Name { get; set; }
        public string TypeDocument { get; set; }
        public string NumDocument { get; set; }
        public string Address { get; set; }
        public string  Phone { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public byte[] PasswordHash { get; set; }
        
        [Required]
        public byte[] PasswordSalt { get; set; }
        public bool Condition { get; set; }

        public Role  Role { get; set; }
        public string RoleName => Role.Name;

    }
}
