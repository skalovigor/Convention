using MediatR;

namespace Convention.BLL.Features.Speaker.Queries
{
    public record SpeakerGetByUserIdQuery(string UserId) : IRequest<Domain.Models.Speaker>
    {
        public static SpeakerGetByUserIdQuery Of(string userId)
        {
            return new (userId);
        }
    }
}