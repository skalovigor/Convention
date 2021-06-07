using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Queries;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    internal class SpeakerGetByIdQueryHandler : IRequestHandler<SpeakerGetByIdQuery, Domain.Models.Speaker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.Speaker> Handle(SpeakerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            return speaker;
        }
    }
}