using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Queries
{
    public record SpeakerGetByIdQuery(Guid SpeakerId) : IRequest<Domain.Speaker>
    {
        public static SpeakerGetByIdQuery Of(Guid speakerId)
        {
            return new (speakerId);
        }
    }

    internal class SpeakerGetByIdQueryHandler : IRequestHandler<SpeakerGetByIdQuery, Domain.Speaker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Speaker> Handle(SpeakerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            return speaker;
        }
    }
}