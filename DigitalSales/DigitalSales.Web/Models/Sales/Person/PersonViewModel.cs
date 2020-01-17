using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalSales.Web.Models.Sales.Person
{
    public class PersonViewModel
    {
        public int IdPerson { get; set; }
        public string Type_person { get; set; }
        public string Name { get; set; }
        public string Type_document { get; set; }
        public string Num_document { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Condition { get; set; }

    }
}
