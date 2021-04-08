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
    public class StateService : IStateService
    {

        IStateRepositoryAsync _stateRepository;

        public ILogger<EmailService> _logger { get; }

        public StateService(ILogger<EmailService> logger, IStateRepositoryAsync stateRepository)
        {        
            _logger = logger;
            _stateRepository = stateRepository;
        }

        public async Task<List<State>> GetStates()
        {
            return (List<State>)await _stateRepository.GetAllAsync();
        }        
    }
}
