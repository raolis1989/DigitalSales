using DigitalSales.Entities.Warehouse;
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
        public int idRole { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="El nombre no tiene el maximo numero de caracteres")]
        public string  Name { get; set; }
        public string Type_Document { get; set; }
        public string Num_Document { get; set; }
        public string Address { get; set; }
        public string  Phone { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public byte[] Password_Hash { get; set; }
        
        [Required]
        public byte[] Password_Salt { get; set; }
        public bool Condition { get; set; }

        public Role  Role { get; set; }
        public string RoleName => Role.Name;

        public ICollection<Entry> Entries { get; set; }
   

    }
}
