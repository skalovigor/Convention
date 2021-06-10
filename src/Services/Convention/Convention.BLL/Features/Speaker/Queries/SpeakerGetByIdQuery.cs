using System;
using MediatR;

namespace Convention.BLL.Features.Speaker.Queries
{
    public record SpeakerGetByIdQuery(Guid SpeakerId) : IRequest<Domain.Models.Speaker>
    {
        public static SpeakerGetByIdQuery Of(Guid speakerId)
        {
            return new (speakerId);
        }
    }
}