using AutoMapper;
using Develo.Application.Features.Products.Commands.CreateProduct;
using Develo.Application.Features.Products.Queries.GetAllProducts;
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
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
