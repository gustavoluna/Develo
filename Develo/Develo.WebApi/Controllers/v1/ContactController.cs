using Develo.Application.Features.Cities.Queries.GetCitiesByProvince;
using Develo.Application.Filters;
using Develo.Application.Interfaces;
using Develo.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Develo.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactController : BaseApiController
    {
        
        public ContactController()
        {
            
        }


        [HttpPost("SendContact")]
        public async Task<IActionResult> SendContact(Contact ccontact)
        {

            var client = new RestClient("https://imc-hiring-test.azurewebsites.net/Contact/Save");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "e5f5c729-9c66-f4d5-c2a8-2b4db849e467");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            //request.AddParameter("application/json", "{\n\t   \"Name\" :\"Gustavo\",\n         \"Address\":\"street 1\",\n         \"Address2\":\"Jd Londrina\",\n         \"City\":\"Sao paulo\",\n         \"Province\":\"AB\",\n         \"Email\" :\"luna.gustavo!gmail.com\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", JsonConvert.SerializeObject(ccontact), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            dynamic json = JsonConvert.DeserializeObject(response.Content);

            return Ok(response.Content);

        }
    }
}
