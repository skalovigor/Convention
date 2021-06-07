using System;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetByIdWithParticipantsQuery(Guid Id) : IRequest<Domain.Models.Convention>
    {
        public static ConventionGetByIdWithParticipantsQuery Of(Guid id)
        {
            return new(id);
        }
    }
}