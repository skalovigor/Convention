using System;
using Convention.BLL.Infrastructure.Behaviours;
using MediatR;

namespace Convention.BLL.Features.Participant.Commands
{
    public record ParticipantCreateCommand : IRequest,
        IValidateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ConventionId { get; set; }
        public string UserId { get; set; }

    }
}