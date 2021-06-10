using System;
using Convention.BLL.Infrastructure.Behaviours;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkCreateCommand : IRequest,
        IValidateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int AmountOfSeats { get; set; }
        public Guid SpeakerId { get; set; }
        public Guid ConventionId { get; set; }
    }

    
}