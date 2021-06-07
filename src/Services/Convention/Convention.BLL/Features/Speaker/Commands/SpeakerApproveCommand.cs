using System;
using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerApproveCommand(Guid SpeakerId) : IRequest
    {
        public static SpeakerApproveCommand Of(Guid speakerId)
            => new(speakerId);
    }
}