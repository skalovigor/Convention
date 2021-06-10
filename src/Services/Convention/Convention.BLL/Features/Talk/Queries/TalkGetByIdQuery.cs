using System;
using MediatR;

namespace Convention.BLL.Features.Talk.Queries
{
    public record TalkGetByIdQuery(Guid TalkId) : IRequest<Domain.Models.Talk>
    {
        public static TalkGetByIdQuery Of(Guid talkId)
            => new(talkId);
    }
}