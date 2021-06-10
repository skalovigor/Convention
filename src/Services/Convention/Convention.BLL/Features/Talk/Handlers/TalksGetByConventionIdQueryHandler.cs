using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Queries;
using Convention.DAL;
using Convention.Domain.Enums;
using MediatR;

namespace Convention.BLL.Features.Talk.Handlers
{
    internal class TalksGetByConventionIdQueryHandler : IRequestHandler<TalksGetApprovedByConventionIdQuery, IReadOnlyCollection<Domain.Models.Talk>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalksGetByConventionIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Models.Talk>> Handle(TalksGetApprovedByConventionIdQuery request, CancellationToken cancellationToken)
        {
            var talks = await _unitOfWork.TalkRepo.WhereAsync(m => m.ConventionId == request.ConventionId
                                                                   && m.Status == TalkStatus.Approved);
            return talks;
        }
    }
}