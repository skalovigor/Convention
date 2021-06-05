using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetByIdQuery(Guid Id) : IRequest<Domain.Convention>
    {
        public static ConventionGetByIdQuery Of(Guid id)
        {
            return new(id);
        }
    }
    
    internal class ConventionGetByIdQueryHandler : IRequestHandler<ConventionGetByIdQuery, Domain.Convention>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Domain.Convention> Handle(ConventionGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.GetAsync(request.Id);
            return result;
        }
    }
}