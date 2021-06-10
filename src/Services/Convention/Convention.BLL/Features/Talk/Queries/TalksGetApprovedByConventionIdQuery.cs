using System;
using System.Collections.Generic;
using MediatR;

namespace Convention.BLL.Features.Talk.Queries
{
    public record TalksGetApprovedByConventionIdQuery(Guid ConventionId) : IRequest<IReadOnlyCollection<Domain.Models.Talk>>
    {
        public static TalksGetApprovedByConventionIdQuery Of(Guid conventionId)
            => new(conventionId);
    }
}