using Develo.Application.DTOs.Email;
using Develo.Application.Exceptions;
using Develo.Application.Interfaces;
using Develo.Application.Interfaces.Repositories;
using Develo.Domain.Entities;
using Develo.Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Develo.Infrastructure.Shared.Services
{
    public class CityService : ICityService
    {

        ICityRepositoryAsync _cityRepository;

        public ILogger<EmailService> _logger { get; }

        public CityService(ILogger<EmailService> logger, ICityRepositoryAsync cityRepository)
        {        
            _logger = logger;
            _cityRepository = cityRepository;
        }


        public async Task<IEnumerable<City>> GetCity(int IdState)
        {
            var ret  = await _cityRepository.GetAllAsync(x => x.IdState == IdState);

            return ret;
        }
    }
}
