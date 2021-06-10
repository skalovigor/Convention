using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Query;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Handlers
{
    internal class ConventionGetByIdWithParticipantsQueryHandler : IRequestHandler<ConventionGetByIdWithParticipantsQuery, Domain.Models.Convention>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetByIdWithParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Domain.Models.Convention> Handle(ConventionGetByIdWithParticipantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.GetWithParticipantsAsync(request.Id);
            return result;
        }
    }
}