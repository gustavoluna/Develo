using AutoMapper;
using Develo.Application.Exceptions;
using Develo.Application.Interfaces.Repositories;
using Develo.Application.Wrappers;
using Develo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Develo.Application.Features.Cities.Queries.GetCitiesByProvince
{
    public class GetCitiesQuery : IRequest<Response<City>>
    {
        public int IdState { get; set; }
    }


    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, Response<City>>
    {
        private readonly ICityRepositoryAsync _cityRepository;
        public GetCitiesQueryHandler(ICityRepositoryAsync cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Response<City>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
        {
            var product = await _cityRepository.GetByIdAsync(query.IdState);
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<City>(product);
        }
    }


}
