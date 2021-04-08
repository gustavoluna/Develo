using Develo.Application.Features.Cities.Queries.GetCitiesByProvince;
using Develo.Application.Filters;
using Develo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Develo.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CityController : BaseApiController
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet("GetAll/{IdState}")]
        public async Task<IActionResult> GetAll(int IdState)
        {
            var result = await _cityService.GetCity(IdState);

            return Ok(result);

        }
    }
}
