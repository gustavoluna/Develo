using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Develo.Domain.Entities
{
    public class State
    {
        [Key]
        public int IdState { get; set; }
        public string Name { get; set; }
    }
}
