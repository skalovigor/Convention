using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using Convention.Domain.Enums;
using MediatR;

namespace Convention.BLL.Features.Talk.Queries
{
    public record TalksGetApprovedByConventionIdQuery(Guid ConventionId) : IRequest<IReadOnlyCollection<Domain.Talk>>
    {
        public static TalksGetApprovedByConventionIdQuery Of(Guid conventionId)
            => new(conventionId);
    }

    internal class TalksGetByConventionIdQueryHandler : IRequestHandler<TalksGetApprovedByConventionIdQuery, IReadOnlyCollection<Domain.Talk>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalksGetByConventionIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Talk>> Handle(TalksGetApprovedByConventionIdQuery request, CancellationToken cancellationToken)
        {
            var talks = await _unitOfWork.TalkRepo.GetAllAsync(m => m.ConventionId == request.ConventionId
                                                  && m.Status == TalkStatus.Approved);
            return talks;
        }
    }
}