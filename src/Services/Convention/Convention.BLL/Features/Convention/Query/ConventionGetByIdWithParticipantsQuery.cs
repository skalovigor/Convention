using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Query
{
    public record ConventionGetByIdWithParticipantsQuery(Guid Id) : IRequest<Domain.Convention>
    {
        public static ConventionGetByIdWithParticipantsQuery Of(Guid id)
        {
            return new(id);
        }
    }
    
    internal class ConventionGetByIdWithParticipantsQueryHandler : IRequestHandler<ConventionGetByIdWithParticipantsQuery, Domain.Convention>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetByIdWithParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Domain.Convention> Handle(ConventionGetByIdWithParticipantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.GetWithParticipantsAsync(request.Id);
            return result;
        }
    }
}