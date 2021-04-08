using AutoMapper;
using Develo.Application.Filters;
using Develo.Application.Interfaces.Repositories;
using Develo.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Develo.Application.Features.States.Queries.GetAllStates
{
    public class GetAllStatesQuery : IRequest<PagedResponse<IEnumerable<GetAllStatesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }


    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, PagedResponse<IEnumerable<GetAllStatesViewModel>>>
    {
        private readonly IStateRepositoryAsync _statetRepository;
        private readonly IMapper _mapper;
        public GetAllStatesQueryHandler(IStateRepositoryAsync statetRepository, IMapper mapper)
        {
            _statetRepository = statetRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllStatesViewModel>>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllStatesParameter>(request);
            var product = await _statetRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<GetAllStatesViewModel>>(product);
            return new PagedResponse<IEnumerable<GetAllStatesViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }

}
