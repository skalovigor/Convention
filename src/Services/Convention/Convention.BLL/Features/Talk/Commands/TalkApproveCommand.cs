using System;
using Convention.BLL.Infrastructure.Behaviours;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkApproveCommand(Guid TalkId) : IRequest,
        IValidateRequest
    {
        public static TalkApproveCommand Of(Guid talkId)
            => new(talkId);
    }

    
}