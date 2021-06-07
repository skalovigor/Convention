using System;
using Convention.BLL.Infrastructure.Behaviours;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkRemoveCommand(Guid TalkId) : IRequest,
        IValidateRequest
    {
        public static TalkRemoveCommand Of(Guid talkId)
            => new(talkId);
    }

    
}