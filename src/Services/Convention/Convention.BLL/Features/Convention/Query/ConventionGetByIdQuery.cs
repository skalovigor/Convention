using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetByIdQuery(Guid Id) : IRequest<Domain.Models.Convention>
    {
        public static ConventionGetByIdQuery Of(Guid id)
        {
            return new(id);
        }
    }
    
    
}