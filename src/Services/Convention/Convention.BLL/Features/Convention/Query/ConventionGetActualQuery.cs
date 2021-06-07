using System.Collections.Generic;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetActualQuery : IRequest<IReadOnlyCollection<Domain.Models.Convention>>
    {
        public static ConventionGetActualQuery Of()
        {
            return new() { };
        }
    }
}