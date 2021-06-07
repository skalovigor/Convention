using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Queries;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    public class SpeakersGetByConventionIdQueryHandler : IRequestHandler<SpeakersGetByConventionIdQuery, IReadOnlyCollection<Domain.Models.Speaker>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakersGetByConventionIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyCollection<Domain.Models.Speaker>> Handle(SpeakersGetByConventionIdQuery request, CancellationToken cancellationToken)
        {
            var speakers = await _unitOfWork.SpeakerRepo.WhereAsync(m => 
                m.Talks.Any(m => m.ConventionId == request.ConventionId));
            return speakers;
        }
    }
}