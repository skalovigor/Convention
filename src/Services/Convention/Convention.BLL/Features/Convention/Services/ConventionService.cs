using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Convention.BLL.Features.Convention.Commands;
using Convention.BLL.Features.Convention.Query;
using Convention.BLL.Features.Identity.Services;
using Convention.Contracts.Models;
using MediatR;

namespace Convention.BLL.Features.Convention.Services
{
    internal sealed class ConventionService : IConventionService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identityContext;

        public ConventionService(IMediator mediator,
            IMapper mapper,
            IIdentityContext identityContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identityContext = identityContext;
        }
        
        public async Task<Guid> Create(ConventionCreateRequest request)
        {
            var id= await _mediator.Send(_mapper.Map<ConventionCreateCommand>(request));
            return id;
        }

        public async Task<List<ConventionResponse>> GetActualList()
        {
            var list= await _mediator.Send(ConventionGetActualQuery.Of());
            return _mapper.Map<List<ConventionResponse>>(list);
        }
    }
}