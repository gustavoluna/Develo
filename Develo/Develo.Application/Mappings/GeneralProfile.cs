using AutoMapper;
using Develo.Application.Features.States.Queries.GetAllStates;
using Develo.Application.Features.Cities.Queries.GetCitiesByProvince;
using Develo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develo.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            
            CreateMap<State, GetAllStatesViewModel>().ReverseMap();
            CreateMap<City, GetCitiesViewModel>().ReverseMap();            
            CreateMap<GetAllStatesQuery, GetAllStatesParameter>();
            
        }
    }
}
