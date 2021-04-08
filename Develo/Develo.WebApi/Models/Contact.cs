using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Develo.WebApi.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }

        public string Province { get; set; }
        public string Email { get; set; }
    }
}

