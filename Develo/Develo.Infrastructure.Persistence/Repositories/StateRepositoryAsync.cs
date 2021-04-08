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
    public class StateRepositoryAsync : GenericRepositoryAsync<State>, IStateRepositoryAsync
    {
        private readonly DbSet<State> _state;

        public StateRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _state = dbContext.Set<State>();
        }

    }
}
