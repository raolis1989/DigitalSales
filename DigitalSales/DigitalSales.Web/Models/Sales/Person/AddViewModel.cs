﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Sales.Person
{
    public class AddViewModel
    {
        [Required]
        public string Type_person { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la persona debe tener mas de 3 caracteres y menos de 100 caracteres")]
        public string Name { get; set; }
        public string Type_document { get; set; }
        public string Num_document { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
