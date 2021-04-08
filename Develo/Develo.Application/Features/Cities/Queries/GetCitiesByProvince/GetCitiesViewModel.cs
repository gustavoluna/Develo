using System;
using System.Collections.Generic;
using System.Text;

namespace Develo.Application.Features.Cities.Queries.GetCitiesByProvince
{
    public class GetCitiesViewModel
    {
        public string IdCity { get; set; }
        public string Name { get; set; }
        
        public int IdState { get; set; }
    }
}
