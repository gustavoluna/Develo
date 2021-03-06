using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Develo.Domain.Entities
{
    public class City
    {
        [Key]
        public int IdCity { get; set; }
        public string Name { get; set; }
        [ForeignKey("State")]
        public int IdState { get; set; }
    }
}
