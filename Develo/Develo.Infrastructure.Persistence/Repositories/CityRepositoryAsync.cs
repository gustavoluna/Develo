using Develo.Application.Interfaces.Repositories;
using Develo.Domain.Entities;
using Develo.Infrastructure.Persistence.Contexts;
using Develo.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Develo.Infrastructure.Persistence.Repositories
{
    public class CityRepositoryAsync : GenericRepositoryAsync<City>, ICityRepositoryAsync
    {
        private readonly DbSet<City> _city;

        public CityRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _city = dbContext.Set<City>();
        }

        public Task<City> GetCitiesByProvince(int IdState)
        {
            throw new NotImplementedException();
        }
    }
}
