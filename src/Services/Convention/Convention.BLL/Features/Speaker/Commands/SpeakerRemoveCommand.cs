using System;
using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerRemoveCommand(Guid SpeakerId) : IRequest
    {
        public static SpeakerRemoveCommand Of(Guid speakerId)
            => new(speakerId);
    }
}