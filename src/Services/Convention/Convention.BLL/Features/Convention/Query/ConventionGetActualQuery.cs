using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetActualQuery : IRequest<IReadOnlyCollection<Domain.Convention>>
    {
        public static ConventionGetActualQuery Of()
        {
            return new() { };
        }
    }
    
    internal class ConventionGetActualQueryHandler : IRequestHandler<ConventionGetActualQuery, IReadOnlyCollection<Domain.Convention>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetActualQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyCollection<Domain.Convention>> Handle(ConventionGetActualQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.GetAllAsync(m=> m.EndDate > DateTime.Now);
            return result;
        }
    }
}