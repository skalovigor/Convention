using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Queries
{
    public record SpeakerGetByUserIdQuery(string UserId) : IRequest<Domain.Speaker>
    {
        public static SpeakerGetByUserIdQuery Of(string userId)
        {
            return new (userId);
        }
    }

    internal class SpeakerGetByUserIdQueryHandler : IRequestHandler<SpeakerGetByUserIdQuery, Domain.Speaker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerGetByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Speaker> Handle(SpeakerGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(m=> m.UserId == request.UserId);
            return speaker;
        }
    }
}