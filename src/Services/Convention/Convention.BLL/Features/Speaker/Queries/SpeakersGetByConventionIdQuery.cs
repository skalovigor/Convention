using System;
using System.Collections.Generic;
using MediatR;

namespace Convention.BLL.Features.Speaker.Queries
{
    public record SpeakersGetByConventionIdQuery(Guid ConventionId) : IRequest<IReadOnlyCollection<Domain.Models.Speaker>>
    {
        public static SpeakersGetByConventionIdQuery Of(Guid conventionId)
        {
            return new (conventionId);
        }
    }
}