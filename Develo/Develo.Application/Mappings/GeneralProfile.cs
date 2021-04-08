using AutoMapper;
using Develo.Application.Features.Products.Commands.CreateProduct;
using Develo.Application.Features.Products.Queries.GetAllProducts;
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
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<State, GetAllStatesViewModel>().ReverseMap();
            CreateMap<City, GetCitiesViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllStatesQuery, GetAllStatesParameter>();
            //CreateMap<GetCitiesQuery, GetCitiesParameter>();
        }
    }
}
