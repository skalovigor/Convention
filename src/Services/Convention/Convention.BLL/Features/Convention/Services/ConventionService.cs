using System;
using System.Threading.Tasks;
using AutoMapper;
using Convention.BLL.Features.Convention.Commands;
using Convention.Contracts.Models;
using MediatR;

namespace Convention.BLL.Features.Convention.Services
{
    internal sealed class ConventionService : IConventionService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ConventionService(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public async Task<Guid> Create(ConventionCreateRequest request)
        {
            var id= await _mediator.Send(_mapper.Map<ConventionCreateCommand>(request));
            return id;
        }
    }
}