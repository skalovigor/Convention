using System;
using System.Threading.Tasks;
using AutoMapper;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Participant.Commands;
using Convention.Contracts.Models.Participant;
using MediatR;

namespace Convention.BLL.Features.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IIdentityContext _identityContext;

        public ParticipantService(IMapper mapper,
            IMediator mediator,
            IIdentityContext identityContext)
        {
            _mapper = mapper;
            _mediator = mediator;
            _identityContext = identityContext;
        }
        
        public async Task ParticipateConvention(Guid conventionId, ParticipantCreateRequest request)
        {
            var command = _mapper.Map<ParticipantCreateCommand>(request);
            await _mediator.Send(command with
            {
                ConventionId = conventionId,
                UserId = _identityContext.User.Id
            });
        }
    }
}