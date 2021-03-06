using Develo.Application.DTOs.Email;
using Develo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Develo.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCity(int IdState);
    }
}
