using Develo.Application.Features.States.Queries.GetAllStates;
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
    public class StateController : BaseApiController
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await Mediator.Send(new GetAllStatesQuery() { PageSize = 100, PageNumber = 1 }));
        }

    }
}
