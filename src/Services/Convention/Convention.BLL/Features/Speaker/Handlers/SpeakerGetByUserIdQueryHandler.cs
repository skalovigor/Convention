using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Queries;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    internal class SpeakerGetByUserIdQueryHandler : IRequestHandler<SpeakerGetByUserIdQuery, Domain.Models.Speaker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerGetByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.Speaker> Handle(SpeakerGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(m=> m.UserId == request.UserId);
            return speaker;
        }
    }
}